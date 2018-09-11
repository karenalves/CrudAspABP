(function () {
    //use strict é um padrão de boa prática
    'use strict';

    //inicialização do angular
    angular
        .module('app')
        .controller('app.views.products.product_index', ProductController)

    //injeção de componentes, como 
    //suporte para modal, serviço de tradução e a appservice de products
    ProductController.$inject =
        [
            '$uibModal',
            'abp.services.app.product',
            '$location',
            '$state',
            '$timeout'
        ];

    function ProductController($uibModal, productService, $location, $state, $timeout) {
        //nunca se esqueça de definir o vm como escopo
        var vm = this;

        //vm.createProduct, é uma variável que pode ser acessada no HTML
        //e que faz referencia a uma função chamada createProduct
        vm.createProduct = createProduct;
        vm.editProduct = editProduct;
        vm.delete = Delete;
        vm.refresh = refresh;

        vm.products = [];

        //chamada da função activate()
        activate();


        function activate() {
            abp.ui.setBusy();
            getProducts();
        }

        function refresh() {
            getProducts();
        }

        function getProducts() {
            productService.getAllProducts({})
                .then(fillProducts, errorMessage)
                .catch(unblockByError);

            function fillProducts(result) {
                vm.products = result.data.produtos;
                abp.ui.clearBusy();
            }

            function unblockByError() {
                abp.ui.clearBusy();
            }
        }

        function errorMessage(result) {
            abp.ui.clearBusy();
            abp.notify.error(result);
        }

        function createProduct() {
            var modalInstance = $uibModal.open({
                templateUrl: '/App/Main/views/products/product_create_or_edit.cshtml',
                controller: 'app.views.products.product_create_or_edit as vm',
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
                getProducts();
            });
        }

        function editProduct(prod) {
            var modalInstance = $uibModal.open({
                templateUrl: '/App/Main/views/products/product_create_or_edit.cshtml',
                controller: 'app.views.products.product_create_or_edit as vm',
                backdrop: 'static',
                resolve: {
                    id: function () {
                        return prod.id;
                    },
                    isEditing: function () {
                        return true;
                    }
                }
            });

            modalInstance.result.then(function () {
                getProducts();
            });
        }

        function Delete(prod) {
            swal({
                title: "Delete product",
                text: "Are you sure you want to delete '" + prod.name + "'?",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false,
                html: false
            }, function () {
                productService.deleteProduct(prod.id)
                    .then(deletedMessage, errorMessage);
                function deletedMessage() {
                    swal("Deleted!",
                        "Your product has been deleted.",
                        "success");
                    getProducts();
                }
            });
        }
    }
})();
