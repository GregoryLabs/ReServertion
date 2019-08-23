var table;

$(document).ready(function () {
    DataTable();
   
});

function DataTable() {
    table = $('#myTable').DataTable
        ({
            scroller: true, scrollX: true, "autoWidth": false,
            stateSave: true,
            "pagingType": "full_numbers",
            "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]],
            buttons: ['colvis'],//, 'copy', 'csv', 'pdf'
            colReorder: true,
            select: true,
            fixedHeader: true,
            //      L = how many entries to show
            //      I = Showing 1 to 8 of 8 entries
            //      F = search field
            //      T = table
            //      R = pRocessing
            //      p - Pagination
            //      < and > - div elements
            //      < "#id" and > - div with an id
            //      < "class" and > - div with a class
            //      "#id.class" and > - div with an id and class
            dom: ' <"top l" <"form-inline" f<"ml-2"B>> > <"mid" t > <"bot mt-2" <"l"li> <"r"p> > '
        });

    $('#myTable').dataTable().fnAdjustColumnSizing();
}
