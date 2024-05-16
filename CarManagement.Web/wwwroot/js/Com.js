var Common = {
    CompanyId: '-1',
    init: function () {
        $("#divFilters").hide();
        $("#divSorting").hide();
        $(".overlay").css('display', 'none');
    },

    /* this is used to show filter on listing screen */
    showFilter: function (element, id) {
        $(id).toggle();
        $(id).click(function (element) {
            element.stopPropagation();
        });
        $(element).toggleClass('active');
    },

    /* this is used to hide filter on listing screen */
    hideFilter: function (self, id) {
        $(self).hide();
        $('.nt-sort, .nt-filter').removeClass('active');
    },

    /* this is used to open a drawer */
    openDrawer: function (self, Action, CompanyId) {
        Common.showLoader();
        console.log(CompanyId);
        $(".drawer-inner", self).animate({
            right: "0"
        });
        $("body").addClass('overflow-hidden');
        $(".overlay", self).css('display', 'block');
        Common.hideLoader();
        if (Action === "View") {
            $.ajax({
                url: `/Company/GetCompany?id=${CompanyId}`,
                method: 'GET',
                dataType: 'json',
                success: function (response) {

                    $("#View-Header-CompanyName").text(response.companyName);

                    $("#View-EstablishedDate").text(response.establishedDate);

                    $("#View-CEO").text(response.ceo);

                    $("#View-Location").text(response.location);

                    $("#View-IsFinanceProvider").text(response.isFinanceProvider);

                    $("#View-Car").text(response.phoneNo ? response.phoneNo : "Provide First");

                },

                error: function (xhr, status, error) {

                    console.error(status + ': ' + error);

                }

            });

        } else if (Action === "Add") {

            this.CompanyId = '-1';

            $("#AddEdit-Title").text('Add Company');

        } else if (Action == "Edit") {

            this.CompanyId = CompanyId;

            $.ajax({

                url: `/Company/GetCompany?id=${CompanyId}`,

                method: 'GET',

                dataType: 'json',

                success: function (response) {

                    $("#AddEdit-Title").text(response.companyName);

                    $("#txtCompanyName").val(response.companyName);

                    $("#txtEstablishedDate").val(response.establishedDate);

                    $("#txtCEO").val(response.ceo);

                    $("#txtLocation").val(response.location);
                    console.log(response.isFinanceProvider);
                   
                    if (response.isFinanceProvider) {
                        $("#txtselectFinanceStatus").val('1'); 
                    } else {
                        $("#txtselectFinanceStatus").val('2'); 
                    }

                },

                error: function (xhr, status, error) {

                    console.error(status + ': ' + error);

                }

            });


        }
    },

    /* this is used to close a drawer */
    closeDrawer: function (self) {
        Common.showLoader();
        $(".drawer-inner", self).animate({
            right: "-100%"
        });
        $("body").removeClass('overflow-hidden');
        $(".overlay", self).css('display', 'none');
        Common.hideLoader();
    },

    /* this is used to show loader */
    showLoader: function () {
        $(".loading-wrapper").show();
    },

    /* this is used to hide loader */
    hideLoader: function () {
        $(".loading-wrapper").hide();
    },

    /* this is used to show project name edit option */
    ShowEditOption: function (element) {
        $(element).next(".edit-name").show();
    },

    /* this is used to hide project name edit option */
    CloseEditOption: function (element) {
        $(element).parents(".edit-name").hide();
    },
    OnSave: function () {
        var createCompanyVM = {};
        createCompanyVM.CompanyName = $('#txtCompanyName').val();
        var establishedDate = new Date($('#txtEstablishedDate').val());
        createCompanyVM.EstablishedDate = establishedDate.toISOString();
        createCompanyVM.CEO = $('#txtCEO').val();
        createCompanyVM.Location = $('#txtLocation').val();

        if ($('#txtselectFinanceStatus').val() == '1') {
            createCompanyVM.IsFinanceProvider = true

        }
        else {
            createCompanyVM.IsFinanceProvider = false
        }
        if (this.CompanyId === '-1') {
            //Add
            console.log(createCompanyVM);
            if (createCompanyVM.CompanyName === "" || createCompanyVM.EstablishedDate === "" || createCompanyVM.CEO === "" || createCompanyVM.Location === "") {
                $('#Add-Update-Message').text('All fields are Required');
                return;
            }
            $.ajax({
                url: '/Company/AddCompany',
                method: 'POST',
                dataType: 'json',
                data: createCompanyVM,
                success: function (response) {
                        console.log(response);
                        var contentElements = document.getElementsByClassName('alerts-content-single');
                            $('.alerts-content').append(`<div class="alerts-content-single" data-userid="${response.companyId}">
						<div class="alerts-content-inner">
							<div class="content-main">
								<div class="content-title">
									<span>${response.companyName}</span><em class="nt-edit edit-name-btn" onclick="Common.ShowEditOption(this)"></em>
									<div class="edit-name">
										<div class="edit-box">
											<input type="text" class="name-input">
											<button class="secondary-btn" type="button" onclick="Common.CloseEditOption(this)">Cancel</button>
											<button class="btn-invite" type="button">Save</button>
										</div>
									</div>
								</div>
								<div class="content-desc">
									${response.establishedDate}
								</div>
							</div>
						</div>
						<div class="alerts-content-inner">
							<div class="content-main">
								<div class="content-desc">
									${response.ceo}
								</div>
							</div>
						</div>
						<div class="alerts-content-inner">
							<div class="content-main">
								<div class="content-desc">
									${response.location}
								</div>
							</div>
						</div>
						<div class="alerts-content-inner">
							<div class="content-main">
								<div class="content-last">
									<span class="closed btn-all-case @((item.${response.isFinanceProvider} ? "green" : "red"))">
										<i class="nt-tick"></i>
										<span class="alert-text">
											${response.isFinanceProvider}
										</span>
									</span>
									<div class="edit-links">
										<em class="nt-more"></em>
										<div class="link-box">
											<div class="link" onclick="Common.openDrawer('#drawerViewProject','View','@item.CompanyId')">
												<em class="nt-eye"></em>
												View
											</div>
											<div class="link" onclick="Common.openDrawer('#drawerAddEditProject','Edit','@item.CompanyId')">
												<em class="nt-edit"></em>
												Edit
											</div>
											<div class="link" onclick="Common.DeleteCompany('@item.CompanyId')">
												<em class="nt-bin"></em>
												Delete
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>`)
                    $('#txtCompanyName').val('');
                    $('#txtEstablishedDate').val('');
                    $('#txtCEO').val('');
                    $('#txtLocation').val('');
                    $('#txtselectFinanceStatus').val('1');
                        Common.closeDrawer();
                },
                error: function (xhr, status, error) {
                    console.error(status + ': ' + error);
                }
            });
        } 
        else {
            //Edit
            $.ajax({
                url: `/Company/EditCompany?id=${this.CompanyId}`,
                method: 'PUT',
                dataType: 'json',
                data: createCompanyVM,
                success: function (response) {
                    console.log(response);
                    var contentElements = document.getElementsByClassName('alerts-content-single');
                    $('.alerts-content').append(`<div class="alerts-content-single" data-userid="${response.companyId}">
						<div class="alerts-content-inner">
							<div class="content-main">
								<div class="content-title">
									<span>${response.companyName}</span><em class="nt-edit edit-name-btn" onclick="Common.ShowEditOption(this)"></em>
									<div class="edit-name">
										<div class="edit-box">
											<input type="text" class="name-input">
											<button class="secondary-btn" type="button" onclick="Common.CloseEditOption(this)">Cancel</button>
											<button class="btn-invite" type="button">Save</button>
										</div>
									</div>
								</div>
								<div class="content-desc">
									${response.establishedDate}
								</div>
							</div>
						</div>
						<div class="alerts-content-inner">
							<div class="content-main">
								<div class="content-desc">
									${response.ceo}
								</div>
							</div>
						</div>
						<div class="alerts-content-inner">
							<div class="content-main">
								<div class="content-desc">
									${response.location}
								</div>
							</div>
						</div>
						<div class="alerts-content-inner">
							<div class="content-main">
								<div class="content-last">
									<span class="closed btn-all-case @((item.${response.isFinanceProvider} ? "green" : "red"))">
										<i class="nt-tick"></i>
										<span class="alert-text">
											${response.isFinanceProvider}
										</span>
									</span>
									<div class="edit-links">
										<em class="nt-more"></em>
										<div class="link-box">
											<div class="link" onclick="Common.openDrawer('#drawerViewProject','View','@item.CompanyId')">
												<em class="nt-eye"></em>
												View
											</div>
											<div class="link" onclick="Common.openDrawer('#drawerAddEditProject','Edit','@item.CompanyId')">
												<em class="nt-edit"></em>
												Edit
											</div>
											<div class="link" onclick="Common.DeleteCompany('@item.CompanyId')">
												<em class="nt-bin"></em>
												Delete
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>`)
                    $('#txtCompanyName').val('');
                    $('#txtEstablishedDate').val('');
                    $('#txtCEO').val('');
                    $('#txtLocation').val('');
                    $('#txtselectFinanceStatus').val('1');
                    Common.closeDrawer();
                },
            });
        }
    },
    DeleteUser: function (CompanyId) {
        if (confirm('Are you sure you want to delete this record?')) {
            $.ajax({
                url: `/Company/DeleteCompany?id=${CompanyId}`,
                method: 'DELETE',
                dataType: 'json',
                success: function (response) {
                    var $userElement = $(".alerts-content-single[data-userid='" + CompanyId + "']");

                    if (response.success) {
                        $userElement.fadeOut("slow", function () {
                            $userElement.remove();
                        });
                    } else {
                        alert(response.message);
                    }
                },
                error: function (xhr, status, error) {
                    console.error(status + ': ' + error);
                }
            });
        }
    }

};


$(document).ready(function () {
    Common.init();
});
