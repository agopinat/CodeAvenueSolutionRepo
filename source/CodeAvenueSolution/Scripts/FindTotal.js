$(document).ready(function () { 
     calculateTotal();
});

function calculateTotal() {
    var total = 0;
    //reference the rows you want to add
    //this will not include the header row
    var rows = $("#Cart tr:gt(0)");

    rows.children("td:nth-child(6)").each(function () {
        //each time we add the cell to the total
        total += parseInt($(this).html());
    });

    //then output them to the elements
    $("#total").html(total.toFixed(2));
}