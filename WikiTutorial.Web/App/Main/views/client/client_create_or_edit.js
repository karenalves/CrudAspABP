(function () {
    'use strict';

    angular
        .module('app')
        .controller('app.views.client.client_create_or_edit', ClienteModalController)

    ClienteModalController.$inject =
        [
            '$scope',
            '$uibModalInstance',
            'abp.services.app.client',
            'id',
            'isEditing'
        ];

    function ClienteModalController($scope, $uibModalInstance, clienteService, id, isEditing) {
        var vm = this;
        vm.save = save;
        vm.cancel = cancel;

        vm.isEditing = isEditing;
        vm.product = {};

        activate();

        function activate() {
            if (isEditing) {
                abp.ui.setBusy();
                getCliente();
            }
        }

        function getCliente() {
            clienteService.getByIdClient(id)
                .then(fillCliente, errorMessage)
                .catch(unblockByError);

            function fillCliente(result) {
                abp.ui.clearBusy();
                vm.cliente = result.data;
            }
        }

        function create() {
            abp.ui.setBusy();
            clienteService.createClient(vm.cliente)
                .then(success)

                .catch(unblockByError);
        }

        function update() {
            abp.ui.setBusy();
            clienteService.updateClient(vm.cliente)
                .then(success)

                .catch(unblockByError);
        }

        function success() {
            abp.ui.clearBusy();
            $uibModalInstance.close({});
        }

        function errorMessage(result) {
            abp.ui.clearBusy();
            abp.notify.error(result);
        }

        function unblockByError(error) {
            console.log(error);
            abp.ui.clearBusy();
        }

        function save() {
            if (isEditing) {
                update();
            } else {
                create();
            }
        };

        function cancel() {
            $uibModalInstance.dismiss({});
        };
    }

})();