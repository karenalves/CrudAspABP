(function () {
    //use strict é um padrão de boa prática
    'use strict';

    //inicialização do angular
    angular
        .module('app')
        .controller('app.views.client.client_index', ClienteController)

    //injeção de componentes, como suporte para modal, serviço de tradução e a appservice de products
    ClienteController.$inject =
        [
            '$uibModal',
            'abp.services.app.client',
            '$location',
            '$state',
            '$timeout'
        ];

    function ClienteController($uibModal, clienteService, $location, $state, $timeout) {
        / jshint validthis:true /

        //nunca se esqueça de definir o vm como escopo
        var vm = this;

        //vm.createProduct, é uma variável que pode ser acessada no HTML
        //e que faz referencia a uma função chamada createProduct
        vm.createCliente = createCliente;
        vm.editCliente = editCliente;
        vm.delete = Delete;
        vm.refresh = refresh;

        vm.cliente = [];

        //chamada da função activate()
        activate();

        function activate() {
            abp.ui.setBusy();
            getCliente();
        }

        function refresh() {
            getCliente();
        }

        function getCliente() {
            clienteService.getAllClient({})
                .then(fillCliente, errorMessage)
                .catch(unblockByError);

            function fillCliente(result) {
                vm.cliente = result.data.client;
                app.ui.clearBusy();
            }

            function unblockByError() {
                abp.ui.clearBusy();
            }
        }

        function errorMessage(result) {
            abp.ui.clearBusy();
            abp.notify.error(result);
        }

        function createCliente() {
            var modalInstance = $uibModal.open({
                templateUrl: '/App/Main/views/client/client_create_or_edit.cshtml',
                controller: 'app.views.client.client_create_or_edit as vm',
                backdrop: 'static',
                resolve: {
                    id: function () {
                        return 0;
                    },
                    isEditing: function () {
                        return false;
                    }
                }
            });

            modalInstance.result.then(function () {
                getCliente();
            });
        }

        function editCliente(cliente) {
            var modalInstance = $uibModal.open({
                templateUrl: '/App/Main/views/client/client_create_or_edit.cshtml',
                controller: 'app.views.client.client_create_or_edit as vm',
                backdrop: 'static',
                resolve: {
                    id: function () {
                        return cliente.id;
                    },
                    isEditing: function () {
                        return true;
                    }
                }
            });

            modalInstance.result.then(function () {
                getCliente();
            });
        }

        function Delete(cliente) {
            swal({
                title: "Delete cliente",
                text: "Are you sure you want to delete '" + cliente.name + "'?",
                type: "warning",
                showCancelButton: true,
                confirmButtonCollor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false,
                html: false
            }, function () {
                clienteService.deleteClient(cliente.id)
                    .then(deletedMessage, errorMessage);
                function deletedMessage() {
                    swal("Deleted!",
                        "Your cliente has been deleted.",
                        "success");
                    getCliente();
                }
            });
        }
    }
})();