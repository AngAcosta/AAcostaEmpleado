$(document).ready(function () { //click
    GetAll();
    EstadoGetall();
});


function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5211/api/Empleado/GetAll',
        success: function (result) { //200 OK 
            $('#tblEmpleado tbody').empty();
            $.each(result.objects, function (i, empleado) {
                var filas =
                    '<tr>'
                    + '<td class="text-center"> <button class="btn btn-warning" onclick="GetById(' + empleado.idEmpleado +')"></td>'
                    + "<td  id='idEmpleado' style='display:none'>" + empleado.idEmpleado + "</td>"
                    + "<td class='text-center'>" + empleado.numeroNomina + "</td>"
                    + "<td class='text-center'>" + empleado.nombre + "</ td>"
                    + "<td class='text-center'>" + empleado.apellidoPaterno + "</ td>"
                    + "<td class='text-center'>" + empleado.apellidoMaterno + "</ td>"
                    + "<td style='display:none'>" + empleado.estado.idEstado + "</td>"
                    + "<td class='text-center'>" + empleado.estado.nombre + "</td>"
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Delete(' + empleado.idEmpleado + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'

                    + "</tr>";
                $("#tblEmpleado tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};

function EstadoGetall() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5211/api/Estado/GetAllEstado',
        success: function (result) {
            $("#ddlEstado").append('<option value="' + 0 + '">' + 'Seleccione una opción' + '</option>');
            $.each(result.objects, function (i, estado) {
                $("#ddlEstado").append('<option value="' + estado.idEstado + '">' + estado.nombre + '</option>');
            });
        }
    });
}

function Add(empleado) {

    var empleado = {
        idEmpleado: 0,
        numeroNomina: $('#txtNumeroNomina').val(),
        nombre: $('#txtNombre').val(),
        apellidoPaterno: $('#txtApellidoPaterno').val(),
        apellidoMaterno: $('#txtApellidoMaterno').val(),
        Estado: {
            idEstado: $('#ddlEstado').val()
        }
    }

    $.ajax({
        type: 'POST',
        url: 'http://localhost:5211/api/Empleado/Add',
        dataType: 'json',
        data: JSON.stringify(empleado),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');
            GetAll();
        }
    });
};

function Update(empleado) {
    var empleado = {
        idEmpleado: $('#txtIdEmpleado').val(),
        numeroNomina: $('#txtNumeroNomina').val(),
        nombre: $('#txtNombre').val(),
        apellidoPaterno: $('#txtApellidoPaterno').val(),
        apellidoMaterno: $('#txtApellidoMaterno').val(),
        Estado: {
            idEstado: $('#ddlEstado').val()
        }
    }

    $.ajax({
        type: 'POST',
        url: 'http://localhost:5211/api/Empleado/Update',
        datatype: 'json',
        data: JSON.stringify(empleado),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');
            GetAll();
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};

function GetById(idEmpleado) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5211/api/Empleado/GetById/' + idEmpleado,
        success: function (result) {
            $('#txtIdEmpleado').val(result.object.idEmpleado);
            $('#txtNumeroNomina').val(result.object.numeroNomina);
            $('#txtNombre').val(result.object.nombre);
            $('#txtApellidoPaterno').val(result.object.apellidoPaterno);
            $('#txtApellidoMaterno').val(result.object.apellidoMaterno);
            $('#ddlEstado').val(result.object.estado.idEstado);

            $('#ModalUpdate').modal('show');
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};

function Delete(idEmpleado) {

    if (confirm("¿Estas seguro de eliminar al Empleado seleccionado?")) {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:5211/api/Empleado/Delete/'+idEmpleado,
            success: function (result) {
                $('#myModal').modal();
                GetAll();
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });

    };
};

function Actualizar() {

    var empleado = {
        idEmpleado: $('#txtIdEmpleado').val(),
        numeroNomina: $('#txtNumeroNomina').val(),
        nombre: $('#txtNombre').val(),
        apellidoPaterno: $('#txtApellidoPaterno').val(),
        apellidoMaterno: $('#txtApellidoMaterno').val(),
        Estado: {
            idEstado: $('#ddlEstado').val()
        }
    }

    if (empleado.idEmpleado == 0) {
        Add(empleado);
    }
    else {
        Update(empleado);
    }
};

function Modal() {
    var mostrar = $('#ModalUpdate').modal('show');
    IniciarEmpleado();
};

function IniciarEmpleado() {

    var empleado = {
        IdEmpleado: $('#txtIdEmpleado').val(''),
        NumeroNomina: $('#txtNumeroNomina').val(''),
        Nombre: $('#txtNombre').val(''),
        ApellidoPaterno: $('#txtApellidoP').val(''),
        ApellidoMaterno: $('#txtApellidoM').val(''),
        Estado: {
            IdEstado: $('#ddlEstado').val(0)
        }
    }
}