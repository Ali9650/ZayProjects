$(function () {

    var ul = $('#collapseTwo');
    var buttons = ul.find("li");
    var productRow = $(".productRow");

    buttons.each(function () {
        $(this).on("click", function () {
            let categoryId = $(this).find("a").attr("categoryId");

            $.ajax({
                url: "/Shop/ShowProducts",
                method: "GET",
                data: {
                    categoryId: categoryId
                },
                contentType: "application/json",
                success: function (response) {
                    productRow.html(response)
                }
            });
        })
    })

});