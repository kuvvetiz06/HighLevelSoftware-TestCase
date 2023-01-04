

var RenderImageColumn = function (data) {
    
    var span = '';
    if (data != null) {
        span = '<img src="' + data + '" class="img-fluid img-thumbnail" style="height: 50px; width: 50px; object-fit: contain;">';
        return span;

    } else {
        return span;
    }

}




var AjaxDataSource = function () {

    var initTable = function () {

        var table = $('#Products');

        table.dataTable({
            dom: 'Bfrtip',
            responsive: true,
            colReorder: true,
            order: [],
            paging: true,
            deferRender: true,
            scrollCollapse: false,
            scroller: true,
            searching: true,


            ajax: {
                url: 'https://api.kitapbulal.com/test/getproducts',
                type: 'GET',
                "dataSrc": "",
            },

            columns: [
                { data: 'imageUrl', 'autoWidth': true },
                { data: 'name', 'autoWidth': true },
                { data: 'price', 'autoWidth:': true },


            ],

            columnDefs: [

                {
                    targets: 0,
                    render: function (data, type, full, meta) {
                        var Img = RenderImageColumn(data);
                        return Img;
                    }
                },

                {

                    targets: 2,
                    render: $.fn.dataTable.render.number('.', ',', 2, '₺')

                },

            ],



        });



    };


    return {


        init: function () {
            initTable();

        },

    };


}();

jQuery(document).ready(function () {
    AjaxDataSource.init();
});

