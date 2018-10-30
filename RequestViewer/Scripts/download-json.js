$(function () {

    toastr.options.fadeOut = 1500;

    $("#download-btn").on("click", function () {
        downloadJson().done(function (data) {
            if (data) {
                var blob = new Blob([JSON.stringify(data)], {
                    type: "text/plain;charset=utf-8;",
                });
                saveAs(blob, "request-json");
            }
            else (toastr.warning("Sorry but something seems to have gone wrong, no data is available"))
        });
    });

    function downloadJson() {
        var defer = $.Deferred();
        defer.promise(
            $.ajax({
                url: "../Home/GetJson",
                data: null,
                success: function (data) {
                    defer.resolve(data);
                    toastr.success('The json has been saved.', 'Success');
                },
                error: function () {
                    toastr.error("There has been an error in transit");
                }
            })
        );
        return defer;
    }

    $(".download-tb").on("click" ,function () {
        $(this).select();
    });
});