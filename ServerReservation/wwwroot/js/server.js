$('#SSH').on('click', () => {

 
    var IPv4Address = document.getElementById('SSH').value;
    alert("Run SSH ");
    $.post("SSH", { host: IPv4Address }, function () {

        alert("SSH ran");
    });

});