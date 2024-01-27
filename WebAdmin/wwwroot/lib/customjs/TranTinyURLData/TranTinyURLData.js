/*!
 * Entity Model Wise : TranTinyURLData : functions JavaScript Library v1.0 
 * Copyright Kuwait Armed Forces and other contributors
 * Released under the MIT license
 * https://jquery.org/license
 * Date: 2023/11/05 11:37:14 AM
 * PC: Major Mahmud
 */
 
'use strict';





$(function () {
    var LandingTranTinyURLData = "/TranTinyURLData/LandingTranTinyURLData";
    function RedirectToLanding(params) {
        if (typeof params != 'undefined')
            window.location.href = params;
    }
    
    $('body').on('click', '#btnAddTranTinyURLData', function (e) {
        try {
            e.preventDefault();
            if (_cusFormValidate('frmAddTranTinyURLData')) {
            
                
            
                var dataobject = {
                    tinyurlid: $("#tinyurlid").val(),
					tinyurl: $("#tinyurl").val(),
					tinyurlcode: $("#tinyurlcode").val(),
					actualurl: $("#actualurl").val(),
					serviceid: $("#serviceid").val(),
					isactive: $("#isactive").val(),
					otisonetime: $("#otisonetime").val(),
					otisused: $("#otisused").val(),
					otusedtime: $("#otusedtime").val(),
					otusedfromip: $("#otusedfromip").val()
                };
                ajaxPostObjectHandler("/TranTinyURLData/AddTranTinyURLData", dataobject, function (response) {
                    if (response._ajaxresponse.responsestatus == "success") {
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingTranTinyURLData);
                    }
                }, true);
            }

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnEditTranTinyURLData', function (e) {
        try {
            e.preventDefault();
            if (_cusFormValidate('frmEditTranTinyURLData')) {
            
                
                
                var dataobject = {
                     tinyurlid: $("#tinyurlid").val(),
					tinyurl: $("#tinyurl").val(),
					tinyurlcode: $("#tinyurlcode").val(),
					actualurl: $("#actualurl").val(),
					serviceid: $("#serviceid").val(),
					isactive: $("#isactive").val(),
					otisonetime: $("#otisonetime").val(),
					otisused: $("#otisused").val(),
					otusedtime: $("#otusedtime").val(),
					otusedfromip: $("#otusedfromip").val()
                };

                ajaxPostObjectHandler("/TranTinyURLData/EditTranTinyURLData", dataobject, function (response) {
                    console.log(response);
                    if (response._ajaxresponse.responsestatus == "success") {
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingTranTinyURLData);
                    }
                }, true);
            }

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnDeleteTranTinyURLData', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmDeleteTranTinyURLData')) {
                var dataobject = {
                   tinyurlid: $("#tinyurlid").val(),
					tinyurl: $("#tinyurl").val(),
					tinyurlcode: $("#tinyurlcode").val(),
					actualurl: $("#actualurl").val(),
					serviceid: $("#serviceid").val(),
					isactive: $("#isactive").val(),
					otisonetime: $("#otisonetime").val(),
					otisused: $("#otisused").val(),
					otusedtime: $("#otusedtime").val(),
					otusedfromip: $("#otusedfromip").val()
                };
                ajaxPostObjectHandler("/TranTinyURLData/DeleteTranTinyURLData", dataobject, function (response) {
                    if (response._ajaxresponse.responsestatus == "success") {                        
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingTranTinyURLData);
                    }
                }, true);
            }
        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnGoBackTranTinyURLData', function (e) {
        try {
            event.preventDefault();
            window.location.href = LandingTranTinyURLData;
        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });
});