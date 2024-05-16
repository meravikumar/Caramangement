var Common = {
    
    init: function (){
        $("#divFilters").hide();
        $("#divSorting").hide();
        $(".overlay").css('display', 'none');

    },

    /* this is used to show filter on listing screen */
    showFilter:function(element, id){
        $(id).toggle();
        $(id).click(function (element) {
            element.stopPropagation();
        });
        $(element).toggleClass('active');
    },

    AddProduct: function (e) {

        e.preventDefault();

        //var formData = $(e.target).serialize();

        //console.log("Serialized form data:", formData);

        $.ajax({

            url: 'Company/Dumy',

            method: 'GET',
            success: function (response) {
                console.log("ho Gya");
            },

            error: function (xhr, status, error) {

                console.error("Form submission failed:", error);

            }

        });

    },

    /* this is used to hide filter on listing screen */
    hideFilter:function(self, id){
        $(self).hide();
         $('.nt-sort, .nt-filter').removeClass('active');
    },

    /* this is used to open a drawer */
    openDrawer: function(self){
        Common.showLoader();
        $(".drawer-inner", self).animate({right: "0"});
        $("body").addClass('overflow-hidden');
        $(".overlay", self ).css('display', 'block');
        Common.hideLoader();
    },

    /* this is used to close a drawer */
    closeDrawer:function(self){
        Common.showLoader();
        $(".drawer-inner", self ).animate({right: "-100%"});
        $("body").removeClass('overflow-hidden');
        $(".overlay", self).css('display', 'none');
        Common.hideLoader();
    },

    /* this is used to show loader */
    showLoader: function(){
        $(".loading-wrapper").show();
    },

    /* this is used to hide loader */
    hideLoader: function(){
        $(".loading-wrapper").hide();
    },

    /* this is used to show project name edit option */
    ShowEditOption:function(element){
        $(element).next(".edit-name").show();
    },

    /* this is used to hide project name edit option */
    CloseEditOption:function(element){
        $(element).parents(".edit-name").hide();
    }
};

$(document).ready(function() {
    Common.init();
});