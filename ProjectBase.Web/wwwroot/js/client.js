var client = new function () {
    this.save = function (close) {
        var formIsValid = true;
        $('#form-client input[data-val-required]').each(function () {
            if ($(this).val() == "") {
                $("#form-client").valid();
                formIsValid = false;
                return;
            }
        });

        if (!formIsValid)
            return;

        helpers.blockUI();
        var model = helpers.convertFormToObject("form-client");
        $.ajax({
            url: $("#form-client").attr("action"),
            type: model.Id == 0 ? 'POST' : 'PUT',
            data: model
        }).done(function (data, status, response) {
            Swal.fire(
                'Tudo certo!',
                '[HumanEntityName] salva com sucesso',
                'success'
            ).then(() => {
                if (model.Id == 0) {
                    if (close === true) {
                        window.location = $("#btn-cancel").attr("href");
                    } else {
                        window.location = '/Client/update/' + response.responseJSON.id;
                    }
                } else {
                    if (close === true) {
                        window.location = $("#btn-cancel").attr("href");
                    } else {
                        helpers.unblockUI();
                    }
                }
            });
        }).fail(function (data) {
            Swal.fire('Opa, algo errado...', helpers.getErrorMessage(data.responseJSON), 'error').then(() => { helpers.unblockUI(); });
        }).always(function (data, status, response) {
            if (status != "success") { helpers.unblockUI(); }
        });
    }

    this.delete = function (id) {
        Swal.fire({
            icon: 'warning',
            title: 'Tem certeza que deseja excluir essa [HumanEntityName]?',
            showCancelButton: true,
            confirmButtonText: 'Sim',
            cancelButtonText: 'Cancelar',
        }).then((result) => {
            if (result.isConfirmed) {

                helpers.blockUI();
                $.ajax({
                    url: '/Client/delete',
                    type: 'DELETE',
                    data: { id: id }
                }).done(function (data, status, response) {
                    window.location.reload();
                }).fail(function (data) {
                    Swal.fire(
                        'Opa, algo errado...',
                        helpers.getErrorMessage(data.responseJSON),
                        'error'
                    );
                }).always(function () {
                    helpers.unblockUI();
                });

            }
        });
    }
}
