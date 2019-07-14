$(document).ready(function () {
    $('#myTable').DataTable
        ({
            scroller: true, scrollX: true, "autoWidth": false, //horizontal scroll 
            //"scrollY": true,//vertical scroll 500
            stateSave: true,//save the state of a table (its paging position, ordering state etc) so that is can be restored when the user reloads a page, or comes back to the page after visiting a sub-page. 
            "pagingType": "full_numbers",//'First', 'Previous', 'Next' and 'Last' buttons, plus page numbers
            "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]],//set the options for the length of the table
            colReorder: true,//allow col reordering
            select: true, // allow selection
            fixedHeader: true,//fixed header
            //buttons: ['copy', 'pdf'],//add buttons

            //"dom": '<"top"i>rt<"bottom"flp><"clear">'
            //      L = how many entries to show
            //      I = Showing 1 to 8 of 8 entries
            //      F = search field
            //      T = table
            //      R = unknown: pRocessing
            //      p - Pagination
            //      < and > - div elements
            //      < "#id" and > - div with an id
            //      < "class" and > - div with a class
            //      "#id.class" and > - div with an id and class
            //dom: '<lftip><BB>',
            //dom: '<"top"lf>rt<"bottom"p>i',
            //dom: '<"top"lif>rt<"bottom"p><"clear">B',
            //"dom": '<"top"ifr><"bottom">tp<"clear">l'

        });
});