
$(document).ready(function () {
    $('#btnNewProduct').on('click', function () {
        setModalTitle('#modalProduct', 'Novo Produto');
        setProductFields('');
        $('#modalProduct').modal('show');
    });

    $('#productsTable .acoes .edit').on('click', function () {
        var id = $(this).data('id');

        getProduct(id);

        $('#modalProduct').modal('show');
    });

    $('#productsTable .acoes .delete').on('click', function () {
        var id = $(this).data('id');

        deleteProduct(id);
    });
});


function getProduct(id) {
    $.ajax({
        url: "../Product/GetProduct",
        method: 'GET',
        data: {
            productId: id
        },
        success: function (product) {
            setModalTitle('#modalProduct', 'Editar Produto' + product.name);
            setProductFields(product);
        }
    })
}

function deleteProduct(id) {
    $.ajax({
        url: "../Product/DeleteProduct",
        method: 'POST',
        data: {
            productId: id
        }, success: function () {
            location.reload(true);
        }
    });
}

function setProductFields(product) {
    if (product) {
        $('#productName').val(product.name);
        $('#productCategoryId').val(product.categoryId);
        $('#productPrice').val(parseInt(product.price));
        $('#productId').val(product.id);
    } else {
        $('#productName').val('');
        $('#productCategoryId').val('');
        $('#productPrice').val(parseInt(''));
        $('#productId').val('');
    }
}