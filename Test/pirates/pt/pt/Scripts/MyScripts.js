$(document).ready(function () {
    $('#booty').click(function ()
    {
        $('#booty1').addClass("jumbotron");
        var str='';
        var tblstr='';
        $.ajax({
            type: 'GET',
            url: 'Home/Booty/',
            dataType: 'json',
            success: function (data) {
                console.log('succecc:', data);
                $.each(data, function (i, item) {
                    str += '<tr><td>' + item.name+'</td><td>'+item.booty+'</td></tr>'
                });
                tblstr = '<table id="datatable" class="table table-hover"><th>Name</th><th>Booty Total</th>' + str + '</table>';
                // $('#booty1').html(tblstr);
                document.getElementById('booty1').innerHTML = tblstr;
                document.getElementById('datatable').style.color = 'Red';
            },

            error: function () {
                alert('error when loading');
            }
           
        });
        return false;
    });

    $(document).click(function () { $('#booty1').html(""); });

    $('#p').click(function (e)
    {
        e.preventDefault();
        var pirate =
           {
               name: $('#pname').val(),
               date: $('#pdate').val(),
           };
        if (!pirate.name || !pirate.date) { alert("please enter name and date"); }
       
        console.log("pirate"+pirate.name);
        //$.ajax({
        //    type: 'post',
        //    url: 'Home/JaxCreate',
        //   // contentType: 'application/json',
        //    data: {
        //        json: JSON.stringify(pirate)
        //    },
        //    dataType: 'json',
        //    success: function (response) {console.log("success:"+response);},
        //    error: function(){console.log("erro:when loading");}
            
        //});
        //return false;
    });
});