$(".SSH").click(function () {
    var IPv4Address = $(this).val();
    alert("Run SSH: " + IPv4Address);

    $.ajax({
        url: window.location.origin + "/Server/SSH",
        type: "post",
        data: { host: IPv4Address },
        success: function () {
            alert("SSH ran");
        }
    });
});