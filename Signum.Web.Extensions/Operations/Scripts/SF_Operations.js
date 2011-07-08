﻿"use strict";

SF.registerModule("Operations", function () {

    SF.OperationManager = function (_options) {
        this.options = $.extend({
            sender: null,
            prefix: "",
            parentDiv: "",
            operationKey: null,
            isLite: false,
            controllerUrl: null,
            validationOptions: {},
            onOk: null,
            onCancelled: null,
            contextual: false,
            requestExtraJsonData: null
        }, _options);
    };

    SF.OperationManager.prototype = {

        runtimeInfo: function () {
            return new SF.RuntimeInfo(this.options.prefix);
        },

        pf: function (s) {
            return "#" + SF.compose(this.options.prefix, s);
        },

        newPrefix: function () {
            return SF.compose("New", this.options.prefix);
        },

        requestData: function (newPrefix) {
            SF.log("OperationManager requestData");
            var formChildren = "";
            if (SF.isFalse(this.options.isLite)) {
                if (SF.isEmpty(this.options.prefix)) //NormalWindow 
                    formChildren = SF.isEmpty(this.options.parentDiv) ? $(this.options.sender).closest("form").find(":input") : $("#" + this.options.parentDiv + " :input");
                else //PopupWindow
                    formChildren = $(this.pf("panelPopup *") + ", #" + SF.Keys.tabId + ", input:hidden[name=" + SF.Keys.antiForgeryToken + "]");
            }
            else {
                formChildren = $('#' + SF.Keys.tabId + ", input:hidden[name=" + SF.Keys.antiForgeryToken + "]");
            }
            formChildren = formChildren.not(".sf-search-control *");

            var info = this.runtimeInfo();
            var runtimeType = info.runtimeType();

            var serializer = new SF.Serializer();
            serializer.add(formChildren.serialize());

            var myRuntimeInfoKey = SF.compose(this.options.prefix, SF.Keys.runtimeInfo);
            if (formChildren.filter("[name=" + myRuntimeInfoKey + "]").length == 0) {
                var value = SF.isEmpty(runtimeType)
                ? info.createValue(SF.StaticInfo(this.options.prefix).singleType(), info.id(), info.isNew())
                : info.find().val();

                serializer.add(myRuntimeInfoKey, value);
            }

            serializer.add({ isLite: this.options.isLite,
                operationFullKey: this.options.operationKey,
                prefix: newPrefix,
                oldPrefix: this.options.prefix
            });
            serializer.add(this.options.requestExtraJsonData);

            return serializer.serialize();
        },

        contextualRequestData: function (newPrefix) {
            SF.log("OperationManager contextualRequestData");

            var serializer = new SF.Serializer();
            serializer.add($("input:hidden[name=" + SF.Keys.antiForgeryToken + "]").serialize());
            serializer.add({
                isLite: this.options.isLite,
                operationFullKey: this.options.operationKey,
                prefix: newPrefix,
                oldPrefix: this.options.prefix
            })
            serializer.add(this.options.requestExtraJsonData);

            return serializer.serialize();
        },

        ajax: function (newPrefix, onSuccess) {
            SF.log("OperationManager ajax");

            if (SF.Blocker.isEnabled()) {
                return false;
            } else {
                SF.Blocker.enable();
            }

            SF.Notify.info(lang.signum.executing);

            if (SF.isEmpty(newPrefix))
                newPrefix = this.options.prefix;

            var self = this;
            $.ajax({
                url: this.options.controllerUrl,
                data: this.options.contextual ? this.contextualRequestData(newPrefix) : this.requestData(newPrefix),
                success: function (operationResult) {
                    SF.Blocker.disable();
                    if (self.executedSuccessfully(operationResult)) {
                        if (onSuccess != null) {
                            onSuccess(newPrefix, operationResult, self.options.parentDiv);
                        }
                    }
                    else {
                        SF.Notify.error(lang.signum.error, 2000);
                        return;
                    }
                },
                error: function () {
                    SF.Blocker.disable();
                    SF.Notify.error(lang.signum.error, 2000);
                }
            });

            return false;
        },

        submit: function () {
            SF.log("OperationManager submit");

            if (SF.Blocker.isEnabled()) {
                return false;
            }

            var $form = $(this.options.sender).closest("form");
            $form.append(SF.hiddenInput('isLite', this.options.isLite) +
            SF.hiddenInput('operationFullKey', this.options.operationKey) +
            SF.hiddenInput("oldPrefix", this.options.prefix));

            SF.submit(this.options.controllerUrl, this.options.requestExtraJsonData, $form);

            return false;
        },

        executedSuccessfully: function (operationResult) {
            SF.log("OperationManager executedSuccessfully");

            if ((typeof (operationResult) !== "object") || (operationResult.result != "ModelState"))
                return true;

            var modelState = operationResult.ModelState;

            if (SF.isEmpty(this.options.prefix)) {
                new SF.Validator().showErrors(modelState);
            }
            else {
                var info = this.runtimeInfo();
                new SF.PartialValidator({
                    prefix: this.options.prefix,
                    type: info.runtimeType(),
                    id: info.id()
                }).showErrors(modelState);
            }
            return false;
        },

        validateAndSubmit: function () {
            SF.log("OperationManager validateAndSubmit");

            if (SF.Blocker.isEnabled()) {
                return false;
            }

            if (SF.isTrue(this.options.isLite)) {
                this.submit();
            }
            else {
                var onSuccess = function () { this.submit(); };
                var self = this;
                var valOptions = $.extend({ prefix: this.options.prefix }, this.options.validationOptions);
                if (!SF.isEmpty(this.options.parentDiv)) { // So as not to override parentDiv to be set in PartialValidator constructor
                    valOptions.parentDiv = this.options.parentDiv;
                }
                if (!SF.EntityIsValid(valOptions, function () { onSuccess.call(self) }, this.options.sender)) {
                    return;
                }
            }

            return false;
        }
    };

    SF.OperationExecutor = function (_options) {
        SF.OperationManager.call(this, $.extend({
            controllerUrl: null
        }, _options));

        this.validateAndAjax = function (newPrefix, onAjaxSuccess) {
            SF.log("OperationExecutor validateAndAjax");

            if (SF.Blocker.isEnabled()) {
                return false;
            }

            if (SF.isEmpty(newPrefix))
                newPrefix = null;

            onAjaxSuccess = typeof onAjaxSuccess == "undefined" ? SF.opOnSuccessDispatcher : onAjaxSuccess;

            var onSuccess = function () {
                this.ajax(newPrefix, onAjaxSuccess);
            };

            if (SF.isTrue(this.options.isLite)) {
                onSuccess.call(this);
            }
            else {
                var self = this;
                var valOptions = $.extend({ prefix: this.options.prefix }, this.options.validationOptions);
                if (!SF.isEmpty(this.options.parentDiv)) { // So as not to override parentDiv to be set in PartialValidator constructor
                    valOptions.parentDiv = this.options.parentDiv;
                }
                if (!SF.EntityIsValid(valOptions, function () { onSuccess.call(self) }, this.options.sender)) {
                    return;
                }
            }
        };

        this.contextualExecute = function (runtimeType, id) {
            SF.log("OperationExecutor contextualExecute");

            if (SF.Blocker.isEnabled()) {
                return false;
            }

            this.ajax(null, SF.opMarkCellOnSuccess);
        };
    };

    SF.OperationExecutor.prototype = new SF.OperationManager();

    //ConstructorFrom options = OperationManager options + returnType
    SF.ConstructorFrom = function (_options) {
        SF.OperationManager.call(this, $.extend({
            controllerUrl: null,
            returnType: null
        }, _options));

        this.validateAndAjax = function (newPrefix, onAjaxSuccess) {
            SF.log("ConstructorFrom validateAndAjax");

            if (SF.Blocker.isEnabled()) {
                return false;
            }

            if (SF.isEmpty(newPrefix))
                newPrefix = null;

            onAjaxSuccess = typeof onAjaxSuccess == "undefined" ? SF.opOnSuccessDispatcher : onAjaxSuccess;

            var onSuccess = function () {
                this.ajax(newPrefix, onAjaxSuccess);
            }

            if (SF.isTrue(this.options.isLite)) {
                onSuccess.call(this);
            }
            else {
                var self = this;
                var valOptions = $.extend({ prefix: this.options.prefix }, this.options.validationOptions);
                if (!SF.isEmpty(this.options.parentDiv)) { // So as not to override parentDiv to be set in PartialValidator constructor
                    valOptions.parentDiv = this.options.parentDiv;
                }
                if (!SF.EntityIsValid(valOptions, function () { onSuccess.call(self) }, this.options.sender)) {
                    return;
                }
            }
        };

        this.contextualConstruct = function (runtimeType, id) {
            SF.log("ConstructorFrom contextualConstruct");

            if (SF.Blocker.isEnabled()) {
                return false;
            }

            this.ajax(this.newPrefix(), SF.opContextualOnSuccess);
        };
    };

    SF.ConstructorFrom.prototype = new SF.OperationManager();

    SF.DeleteExecutor = function (_options) {
        SF.OperationManager.call(this, $.extend({
            controllerUrl: null
        }, _options));

        this.contextualDelete = function (runtimeType, id) {
            SF.log("DeleteExecutor contextualDelete");

            if (SF.Blocker.isEnabled()) {
                return false;
            }

            SF.Notify.info(lang.signum.executing);
            this.ajax(this.options.prefix, function () {
                SF.Notify.info(lang.signum.executed, 2000);
            });
        };
    };

    SF.DeleteExecutor.prototype = new SF.OperationManager();

    SF.OperationDelete = function (deleteExecutor) {
        deleteExecutor.execute();
    };

    //ConstructorFromMany options = OperationManager options + returnType
    SF.ConstructorFromMany = function (_options) {
        SF.OperationManager.call(this, $.extend({
            controllerUrl: null,
            returnType: null
        }, _options));

        this.requestData = function (newPrefix, items) {
            SF.log("ConstructorFromMany requestData");

            var serializer = new SF.Serializer()
                                .add($('#' + SF.Keys.tabId).serialize())
                                .add($("input:hidden[name=" + SF.Keys.antiForgeryToken + "]").serialize())
                                .add({ runtimeType: $(this.pf(SF.Keys.entityTypeNames)).val(),
                                    operationFullKey: this.options.operationKey,
                                    prefix: newPrefix,
                                    oldPrefix: this.options.prefix
                                });

            for (var i = 0, l = items.length; i < l; i++) {
                serializer.add("ids", items[i].id);
            }

            serializer.add(this.options.requestExtraJsonData);

            return serializer.serialize();
        };

        this.ajax = function (newPrefix, items, onSuccess) {
            SF.log("ConstructorFromMany ajax");

            SF.Notify.info(lang.signum.executing);

            if (SF.Blocker.isEnabled()) {
                return false;
            } else {
                SF.Blocker.enable();
            }

            var self = this;
            $.ajax({
                url: this.options.controllerUrl,
                data: this.requestData(newPrefix, items),
                success: function (operationResult) {
                    SF.Blocker.disable();

                    if (self.executedSuccessfully(operationResult)) {
                        if (onSuccess != null) {
                            onSuccess(newPrefix, operationResult, self.options.parentDiv);
                        }
                    }
                    else {
                        SF.Notify.error(lang.signum.error, 2000);
                        return;
                    }
                },
                error: function () {
                    SF.Blocker.disable();
                    SF.Notify.error(lang.signum.error, 2000);
                }
            });
        };

        this.ajaxSelected = function () {
            SF.log("ConstructorFromMany ajaxSelected");

            if (SF.Blocker.isEnabled()) {
                return false;
            }

            var onSuccess = function (items) {
                this.ajax(this.options.prefix, items, SF.opOnSuccessDispatcher);
            }

            var self = this;
            new SF.FindNavigator({ prefix: this.options.prefix }).hasSelectedItems(function (items) { onSuccess.call(self, items) });
        };

        this.submitSelected = function () {
            SF.log("ConstructorFromMany submitSelected");

            if (SF.Blocker.isEnabled()) {
                return false;
            }

            var onSuccess = function (items) {
                for (var i = 0, l = items.length; i < l; i++) {
                    $(this.options.sender).closest("form").append(SF.hiddenInput('ids', items[i].id));
                }
                this.submit();
            };

            var self = this;
            new SF.FindNavigator({ prefix: this.options.prefix }).hasSelectedItems(function (items) { onSuccess.call(self, items) });
        }
    };

    SF.ConstructorFromMany.prototype = new SF.OperationManager();

    SF.opDisableCtxmenu = function () {
        var clss = "sf-ctxmenu-active";
        $("." + clss).removeClass(clss);
    };

    SF.opOnSuccessDispatcher = function (prefix, operationResult, parentDiv) {
        SF.log("OperationExecutor OpDefaultOnSuccess");
        SF.opDisableCtxmenu();

        if (SF.isEmpty(operationResult)) {
            return null;
        }

        var $result = $(operationResult);
        var newPopupId = SF.compose(prefix, "panelPopup");
        var hasNewPopup = $result.filter("#" + newPopupId).length !== 0;

        //If result is a NormalControl, or an already opened popup => ReloadContent
        if (!hasNewPopup || (hasNewPopup && $("#" + newPopupId + ":visible").length !== 0)) {
            SF.opReloadContent(prefix, operationResult, !SF.isEmpty(parentDiv) ? parentDiv : hasNewPopup ? newPopupId : "");
        }
        else {
            SF.opOpenPopup(prefix, operationResult);
        }
    };

    SF.opReloadContent = function (prefix, operationResult, parentDiv) {
        SF.log("OperationExecutor OpReloadContent");
        SF.opDisableCtxmenu();
        if (SF.isEmpty(prefix)) { //NormalWindow
            var $elem = SF.isEmpty(parentDiv) ? $("#divNormalControl") : $("#" + parentDiv);
            $elem.html(operationResult);
            SF.triggerNewContent($elem);
        }
        else { //PopupWindow
            SF.closePopup(prefix);
            var viewNav = new SF.ViewNavigator({
                prefix: prefix
                //containerDiv: parentDiv /*SF.compose(prefix, "externalPopupDiv")*/
            });
            viewNav.viewOptions.containerDiv = viewNav.tempDivId();
            viewNav.viewSave(operationResult);
        }
        SF.Notify.info(lang.signum.executed, 2000);
    };

    SF.opOpenPopup = function (prefix, operationResult) {
        SF.log("OperationExecutor OpOpenPopup");
        SF.opDisableCtxmenu();
        new SF.ViewNavigator({ prefix: prefix }).showCreateSave(operationResult);
        SF.Notify.info(lang.signum.executed, 2000);
    };

    SF.opOpenPopupNoDefaultOk = function (prefix, operationResult) {
        SF.log("OperationExecutor OpOpenPopupNoDefaultOk");
        SF.opDisableCtxmenu();
        new SF.ViewNavigator({ prefix: prefix, onOk: function () { return false; }, onSave: function () { return false; } }).showCreateSave(operationResult);
        SF.Notify.info(lang.signum.executed, 2000);
    };

    SF.opNavigate = function (prefix, operationResult) {
        SF.submit(operationResult);
    };

    SF.opMarkCellOnSuccess = function (prefix, operationResult) {
        SF.log("OperationExecutor OpMarkCellOnSuccess");
        $(".sf-ctxmenu-active")
            .addClass("sf-entity-ctxmenu-" + (SF.isEmpty(operationResult) ? "success" : "error"))
            .removeClass("sf-ctxmenu-active");

        SF.Notify.info(lang.signum.executed, 2000);
    };

    SF.opContextualOnSuccess = function (prefix, operationResult) {
        SF.log("OperationExecutor OpContextualOnSuccess");
        SF.opDisableCtxmenu();
        if (SF.isEmpty(operationResult)) {
            return null;
        }

        var $result = $(operationResult);
        var newPopupId = SF.compose(prefix, "panelPopup");
        var hasNewPopup = $result.filter("#" + newPopupId).length !== 0;
        //If result is a NormalControl => Load it
        if (hasNewPopup) {
            SF.opOpenPopup(prefix, operationResult)
        }
        else {
            var $form = $("form");
            $form.html(operationResult);
            SF.triggerNewContent($form);
            SF.Notify.info(lang.signum.executed, 2000);
        }
    };

    $(".sf-search-control").live("entity-cell-ctx-menu", function (e, td, findNavigator) {
        SF.log("entity contextmenu");

        var entityCtxMenuUrl = $(findNavigator.pf("divSearchControl")).data("entity-ctx-menu-url");
        if (SF.isEmpty(entityCtxMenuUrl))
            return false; //EntityContextMenu not active

        var $td = $(td);
        $td.addClass("sf-ctxmenu-active");

        var $menu = findNavigator.createCtxMenu($td);
        var $itemContainer = $menu.find(".sf-search-ctxmenu");

        var requestData = {
            lite: $td.parent().data('entity'),
            webQueryName: $(findNavigator.pf(findNavigator.webQueryName)).val(),
            prefix: findNavigator.findOptions.prefix
        };

        $.ajax({
            url: entityCtxMenuUrl,
            data: requestData,
            success: function (items) {
                $itemContainer.html(items);
                $menu.appendTo($td);
                SF.triggerNewContent($menu);
            }
        });

        return false;
    });
});
