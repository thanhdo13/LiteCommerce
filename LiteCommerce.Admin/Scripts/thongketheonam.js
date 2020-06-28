$(document).ready(function() {
    $('#Year').change(function() {
        var nam = $("#Year").val();
        $.ajax({
            type : "GET",
            url: "/Dashboard/Input", // Tên controller
            data: "year=" + nam, // Gán giá trị vào name mục
            //contentType: "application/json; charset=utf-8",
            dataType : "json",
            async : true,
            cache : false,
            success: function (result) {
                console.log(result);
                $('td').remove();
                $.each(result, function (index, dashboard) {
                    $('#ToTal').text(dashboard.Jan + dashboard.Feb + dashboard.Mar + dashboard.Apr + dashboard.May + dashboard.Jun + dashboard.Jul + dashboard.Aug +
                        dashboard.Sep + dashboard.Oct + dashboard.Nov + dashboard.Dec + ' $');
                    $('#nam').text(dashboard.Year);
                    $('#tableThongKe').append("<td>" + dashboard.Jan + " $</td>");
                    $('#tableThongKe').append("<td>" + dashboard.Feb + " $</td>");
                    $('#tableThongKe').append("<td>" + dashboard.Mar + " $</td>");
                    $('#tableThongKe').append("<td>" + dashboard.Apr + " $</td>");
                    $('#tableThongKe').append("<td>" + dashboard.May + " $</td>");
                    $('#tableThongKe').append("<td>" + dashboard.Jun + " $</td>");
                    $('#tableThongKe').append("<td>" + dashboard.Jul + " $</td>");
                    $('#tableThongKe').append("<td>" + dashboard.Aug + " $</td>");
                    $('#tableThongKe').append("<td>" + dashboard.Sep + " $</td>");
                    $('#tableThongKe').append("<td>" + dashboard.Oct + " $</td>");
                    $('#tableThongKe').append("<td>" + dashboard.Nov + " $</td>");
                    $('#tableThongKe').append("<td>" + dashboard.Dec + " $</td>");
                });
                

                            }

                        });
                    });
        });