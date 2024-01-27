/*!
 * Entity Model Wise : TranTinyURLAccessInfo : functions JavaScript Library v1.0 
 * Copyright Kuwait Armed Forces and other contributors
 * Released under the MIT license
 * https://jquery.org/license
 * Date: 2023/11/05 11:37:14 AM
 * PC: Major Mahmud
 */
 
'use strict';





$(function () {
    var LandingTranTinyURLAccessInfo = "/TranTinyURLAccessInfo/LandingTranTinyURLAccessInfo";
    function RedirectToLanding(params) {
        if (typeof params != 'undefined')
            window.location.href = params;
    }
    
    $('body').on('click', '#btnAddTranTinyURLAccessInfo', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmAddTranTinyURLAccessInfo')) {
            
                
            
                var dataobject = {
                    tinyurlacceessid: $("#tinyurlacceessid").val(),
					tinyurlid: $("#tinyurlid").val(),
					otisused: $("#otisused").val(),
					otusedtime: $("#otusedtime").val(),
					otusedfromip: $("#otusedfromip").val()
                };
                ajaxPostObjectHandler("/TranTinyURLAccessInfo/AddTranTinyURLAccessInfo", dataobject, function (response) {
                    if (response._ajaxresponse.responsestatus == "success") {
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingTranTinyURLAccessInfo);
                    }
                }, true);
            }

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnEditTranTinyURLAccessInfo', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmEditTranTinyURLAccessInfo')) {
            
                
                
                var dataobject = {
                     tinyurlacceessid: $("#tinyurlacceessid").val(),
					tinyurlid: $("#tinyurlid").val(),
					otisused: $("#otisused").val(),
					otusedtime: $("#otusedtime").val(),
					otusedfromip: $("#otusedfromip").val()
                };

                ajaxPostObjectHandler("/TranTinyURLAccessInfo/EditTranTinyURLAccessInfo", dataobject, function (response) {
                    console.log(response);
                    if (response._ajaxresponse.responsestatus == "success") {
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK");
                    }
                }, true);
            }

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnDeleteTranTinyURLAccessInfo', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmDeleteTranTinyURLAccessInfo')) {
                var dataobject = {
                   tinyurlacceessid: $("#tinyurlacceessid").val(),
					tinyurlid: $("#tinyurlid").val(),
					otisused: $("#otisused").val(),
					otusedtime: $("#otusedtime").val(),
					otusedfromip: $("#otusedfromip").val()
                };
                ajaxPostObjectHandler("/TranTinyURLAccessInfo/DeleteTranTinyURLAccessInfo", dataobject, function (response) {
                    if (response._ajaxresponse.responsestatus == "success") {                        
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingTranTinyURLAccessInfo);
                    }
                }, true);
            }
        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnGoBackTranTinyURLAccessInfo', function (e) {
        try {
            event.preventDefault();
            window.location.href = LandingTranTinyURLAccessInfo;
        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });
});