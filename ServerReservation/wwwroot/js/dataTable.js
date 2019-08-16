var table;

$(document).ready(function () {
    DataTable();
    DateRangePicker();
    $("#StatusFilter").on("change", StatusFilter);
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

function DateRangePicker() {
    var start = moment().startOf('month');
    var end = moment().endOf('month');

    function cb(start, end) {
        $('#reportrange span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
        $('#start').val(start.format('MM/DD/YYYY'));
        $('#end').val(end.format('MM/DD/YYYY'));
        DateFilter();
    }

    $('#reportrange').daterangepicker({
        startDate: start,
        endDate: end,
        "showDropdowns": true,
        "showWeekNumbers": true,
        "timePicker": true,
        "autoApply": true,
        "alwaysShowCalendars": true,
        ranges: {
            'Today': [moment(), moment()],
            'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
            'Last 7 Days': [moment().subtract(6, 'days'), moment()],
            'Last 30 Days': [moment().subtract(29, 'days'), moment()],
            'This Month': [moment().startOf('month'), moment().endOf('month')],
            'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
        },
        "opens": "center",
        "locale": {
            "format": "MM/DD/YYYY",
            "separator": " - ",
            "applyLabel": "Apply",
            "cancelLabel": "Clear",
            "fromLabel": "From",
            "toLabel": "To",
            "customRangeLabel": "Custom",
            "weekLabel": "W",
            "daysOfWeek": [
                "Su",
                "Mo",
                "Tu",
                "We",
                "Th",
                "Fr",
                "Sa"
            ],
            "monthNames": [
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December"
            ],
            "firstDay": 1
        },
    }, cb);

    $('#reportrange').on('cancel.daterangepicker', function (ev, picker) {
        $('#reportrange span').html('All');
        $('#start').val("");
        $('#end').val("");
        DateFilter();
    });

    cb(start, end);
}

function DateFilter() {
    /* Custom filtering function which will search data between two DATE values */
    $.fn.dataTable.ext.search.push(
        function (settings, data, dataIndex) {
            var iStart = document.getElementById('start').value;
            var iEnd = document.getElementById('end').value;
            iStart = iStart.substring(6, 10) + iStart.substring(0, 2) + iStart.substring(3, 5);
            iEnd = iEnd.substring(6, 10) + iEnd.substring(0, 2) + iEnd.substring(3, 5);

            var iStartDateCol = 2;//NOTE: this is the column to be searched
            var iEndDateCol = 3;//NOTE: this is the column to be searched
            var iDataStart = data[iStartDateCol].substring(6, 10) + data[iStartDateCol].substring(0, 2) + data[iStartDateCol].substring(3, 5);
            var iDataEnd = data[iEndDateCol].substring(6, 10) + data[iEndDateCol].substring(0, 2) + data[iEndDateCol].substring(3, 5);

            if (iStart === "" && iEnd === "") {
                return true;
            }
            else if (iDataEnd === "" && iDataStart <= iEnd) {
                return true;
            }
            else if (iStart <= iDataEnd && iDataEnd <= iEnd) {
                return true;
            }
            else if (iStart <= iDataStart && iDataStart <= iEnd) {
                return true;
            }
            else if (iDataStart <= iStart && iEnd <= iDataEnd) {
                return true;
            }
            return false;
        }
    );
    table.draw();
}

function StatusFilter() {
    /* Custom filtering function which will filter enum text */
    $.fn.dataTable.ext.search.push(
        function (settings, data, dataIndex) {
            var iStatus = $('[id*=StatusFilter] option:selected').text();

            var iStatusCol = 1;//NOTE: this is the column to be searched
            var iDataStatus = data[iStatusCol];

            if (iStatus === iDataStatus) {
                return true;
            }
            return false;
        }
    );
    table.draw();
}
