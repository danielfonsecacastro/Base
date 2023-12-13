var dataTableHelper = new function () {
    this.selectedId = 0;
    this.iniciar = function (settings) {
        var querySelector = (typeof settings !== 'undefined' && typeof settings.querySelector !== 'undefined') ? settings.querySelector : "#datatable-buttons";
        var dom = (typeof settings !== 'undefined' && typeof settings.dom !== 'undefined') ? settings.dom : "frtipl";
        var selectStyle = (typeof settings !== 'undefined' && typeof settings.selectStyle !== 'undefined') ? settings.selectStyle : "single";
        

        var table = $(querySelector).DataTable({
            dom: dom,
            columnDefs: [{
                "targets": 'no-sort',
                "orderable": false,
            }],
            select: {
                style: selectStyle
            },
            language: {
                url: '//cdn.datatables.net/plug-ins/1.13.4/i18n/pt-BR.json',
            },
            drawCallback: function () {
                $(".dataTables_paginate > .pagination").addClass("pagination-rounded")
            }
        });

        if (settings.btInsert !== undefined && settings.btUpdate !== undefined && settings.btDelete !== undefined ) {
            table.on('select', function (e, dt, type, indexes) {
                if (type === 'row') {
                    dataTableHelper.selectedId = table.rows(indexes).data()[0][0];
                    settings.btInsert.disabled = true;
                    settings.btUpdate.disabled = false;
                    settings.btDelete.disabled = false;
                }
            });

            table.on('deselect', function (e, dt, type, indexes) {
                if (type === 'row') {
                    dataTableHelper.selectedId = 0;
                    settings.btInsert.disabled = false;
                    settings.btUpdate.disabled = true;
                    settings.btDelete.disabled = true;
                }
            });

            table.on('dblclick', function (e, dt, type, indexes) {
                dataTableHelper.selectedId = table.rows(indexes).data()[0][0];
                settings.btUpdate.click();
            });
        }
        return table;
    }
}