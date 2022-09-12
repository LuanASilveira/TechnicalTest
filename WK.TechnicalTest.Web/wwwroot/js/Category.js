$(document).ready(function () {
    $('#categoriesTable .acoes .edit').on('click', function () {
        var id = $(this).data('id');

        getCategory(id);

        $('#modalCategory').modal('show');
    });

    $('#categoriesTable .acoes .delete').on('click', function () {
        var id = $(this).data('id');

        deleteCategory(id);
    });

    $('#btnNewCategory').on('click', function () {
        setModalTitle('#modalCategory', 'Nova Categoria');
        setCategoryFields('');
        $('#modalCategory').modal('show');
    });
});

function getCategory(id) {
    $.ajax({
        url: "../Category/GetCategory",
        method: 'GET',
        data: {
            categoryId: id
        },
        success: function (category) {
            setModalTitle('#modalCategory', 'Editar Categoria ' + category.name);
            setCategoryFields(category);
        }
    })
}

function deleteCategory(id) {
    $.ajax({
        url: "../Category/DeleteCategory",
        method: 'POST',
        data: {
            categoryId: id
        }, success: function () {
            location.reload(true);
        }
    });
}

function setCategoryFields(category) {
    if (category) {
        $('#categoryName').val(category.name);
        $('#categoryId').val(category.id);
    }
    else {
        $('#categoryName').val('');
        $('#categoryId').val('');
    }
}