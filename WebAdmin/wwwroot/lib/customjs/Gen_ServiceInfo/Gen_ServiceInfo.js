/*!
 * Entity Model Wise : Gen_ServiceInfo : functions JavaScript Library v1.0 
 * Copyright Kuwait Armed Forces and other contributors
 * Released under the MIT license
 * https://jquery.org/license
 * Date: 2023/01/04 9:12:37 AM
 * PC: Major Mahmud
 */
 
'use strict';




    
$(function () {
    var LandingGen_ServiceInfo = "/Gen_ServiceInfo/LandingGen_ServiceInfo";
    function RedirectToLanding(params) {
        if (typeof params != 'undefined')
            window.location.href = params;
    }
    
    $('body').on('click', '#btnAddGen_ServiceInfo', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmAddGen_ServiceInfo')) {
            
                
            
                var dataobject = {
                    serviceid: $("#serviceid").val(),
					servicear: $("#servicear").val(),
					serviceen: $("#serviceen").val(),
					descriptionar: $("#descriptionar").val(),
					descriptionen: $("#descriptionen").val(),
					isactive: $("#isactive").val()
                };
                ajaxPostObjectHandler("/Gen_ServiceInfo/AddGen_ServiceInfo", dataobject, function (response) {
                    if (response._ajaxresponse.responsestatus == "success") {
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingGen_ServiceInfo);
                    }
                }, true);
            }

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnEditGen_ServiceInfo', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmEditGen_ServiceInfo')) {
            
                
                
                var dataobject = {
                     serviceid: $("#serviceid").val(),
					servicear: $("#servicear").val(),
					serviceen: $("#serviceen").val(),
					descriptionar: $("#descriptionar").val(),
					descriptionen: $("#descriptionen").val(),
					isactive: $("#isactive").val()
                };

                ajaxPostObjectHandler("/Gen_ServiceInfo/EditGen_ServiceInfo", dataobject, function (response) {
                    console.log(response);
                    if (response._ajaxresponse.responsestatus == "success") {
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingGen_ServiceInfo);
                    }
                }, true);
            }

        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnDeleteGen_ServiceInfo', function (e) {
        try {
            event.preventDefault();
            if (_cusFormValidate('frmDeleteGen_ServiceInfo')) {
                var dataobject = {
                   serviceid: $("#serviceid").val(),
					servicear: $("#servicear").val(),
					serviceen: $("#serviceen").val(),
					descriptionar: $("#descriptionar").val(),
					descriptionen: $("#descriptionen").val(),
					isactive: $("#isactive").val()
                };
                ajaxPostObjectHandler("/Gen_ServiceInfo/DeleteGen_ServiceInfo", dataobject, function (response) {
                    if (response._ajaxresponse.responsestatus == "success") {                        
                        showSuccessAlert("Success", response._ajaxresponse.responsetext, "OK", RedirectToLanding, LandingGen_ServiceInfo);
                    }
                }, true);
            }
        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });

    $('body').on('click', '#btnGoBackGen_ServiceInfo', function (e) {
        try {
            event.preventDefault();
            window.location.href = LandingGen_ServiceInfo;
        } catch (e) {
            showErrorAlert("Error", e.message, "OK");
        }
    });
});