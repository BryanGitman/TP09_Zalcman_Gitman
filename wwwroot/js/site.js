// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function HorizontalOVertical(id)
{
    var image = $("#"+id);
    if(image.width() > image.height())
    {
        image.attr('class',"imgH")
    }
}

function MostrarComentarios(IdP,IdU)
{
    $.ajax(
        {
            type: 'POST',
            dataType: 'JSON',
            url: '/Home/VerComentariosAjax',
            data: { IdPost: IdP },
            success:
                function (response)
                {
                    var elem=0;
                    response.forEach(element => {
                        elem++;
                    });
                    if(elem > 0)
                    {
                        $("#comentariostitulo").html("Comentarios (" + elem + ")");
                        var content = "";
                        response.forEach(element => {
                            content += "<div class='row dataPost coment'><div class='circulo'><img src='/" + element.fotoPerfil + "' id='imagenC" + element.id + "'><script>HorizontalOVertical('imagenC" + element.id + "');</script></div><div class='col-sm-9'><div class='user'><p><b>" + element.nombreUsuario + "</b></p><p class='text-muted'>de " + element.paisOrigen + "</p>" + (IdU ==  element.idUsuario ? "<a class='eliminar derecha' data-bs-toggle='modal' data-bs-target='#eliminar' onclick='Eliminar(" + element.id + ",\"c\")'><svg xmlns='http://www.w3.org/2000/svg' width='32' height='32' fill='currentColor' class='bi bi-trash3' viewBox='0 0 16 16'><path d='M6.5 1h3a.5.5 0 0 1 .5.5v1H6v-1a.5.5 0 0 1 .5-.5ZM11 2.5v-1A1.5 1.5 0 0 0 9.5 0h-3A1.5 1.5 0 0 0 5 1.5v1H2.506a.58.58 0 0 0-.01 0H1.5a.5.5 0 0 0 0 1h.538l.853 10.66A2 2 0 0 0 4.885 16h6.23a2 2 0 0 0 1.994-1.84l.853-10.66h.538a.5.5 0 0 0 0-1h-.995a.59.59 0 0 0-.01 0H11Zm1.958 1-.846 10.58a1 1 0 0 1-.997.92h-6.23a1 1 0 0 1-.997-.92L3.042 3.5h9.916Zm-7.487 1a.5.5 0 0 1 .528.47l.5 8.5a.5.5 0 0 1-.998.06L5 5.03a.5.5 0 0 1 .47-.53Zm5.058 0a.5.5 0 0 1 .47.53l-.5 8.5a.5.5 0 1 1-.998-.06l.5-8.5a.5.5 0 0 1 .528-.47ZM8 4.5a.5.5 0 0 1 .5.5v8.5a.5.5 0 0 1-1 0V5a.5.5 0 0 1 .5-.5Z'/></svg></a>" : "") + "</div><p>" + element.contenido + "</p><p class='text-muted derecha'>" + element.fechaComentario.substr(0,10) + "</p></div></div>";
                        });
                        content += "<footer><form method='post' action='/Home/GuardarComentario'><input type='text' name='Contenido' class= 'agcoment' placeholder ='Agregá un comentario' required><input type='hidden' name='IDUsuario' value='" + IdU + "'><input type='hidden' name='FechaComentario' value='" + new Date().toJSON() + "'><input type='hidden' name='IDPublicacion' value='" + IdP + "'><input type='submit' class='btn btn-primary' value = 'Publicar'></form></footer>";
                        $("#comentarioscontenido").html(content);
                    }
                    else
                    {
                        $("#comentariostitulo").html("Comentarios (0)");
                        var content = "<p class='text-center'>No hay comentarios aún. Sé el primero en comentar</p><br>";
                        content += "<footer><form method='post' action='/Home/GuardarComentario'><input type='text' name='Contenido' class= 'agcoment' placeholder ='Agregá un comentario' required><input type='hidden' name='IDUsuario' value='" + IdU + "'><input type='hidden' name='FechaComentario' value='" + new Date().toJSON() + "'><input type='hidden' name='IDPublicacion' value='" + IdP + "'><input type='submit' class='btn btn-primary' value = 'Publicar'></form></footer>";
                        $("#comentarioscontenido").html(content);
                    }
                }
        }
    );
}

function MostrarPerfil()
{
    $.ajax(
        {
            type: 'POST',
            dataType: 'JSON',
            url: '/Home/ObtenerUsuarioAjax',
            success:
            function (response)
            {
                $("#miperfilcontenido").html("<div class='circulo mimarco'><img src='/"+ response.fotoPerfil + "' id='imagen" + response.id + "'><script>HorizontalOVertical('imagen" + response.id + "');</script></div><h5 class='text-center'>" + response.nombreUsuario + "</h5><a class='btn btn-primary opcionesperfil' href='/Home/Home?idUser=" + response.id + "&idDest=0'>Mis Publicaciones</a><a class='btn btn-danger opcionesperfil' href='/Home/PostsLikeados'>Publicaciones que me gustan</a><a class='btn btn-success opcionesperfil' href='/Home/Index'>Cerrar Sesion</a>");
            }
        }
    );
}

function AccesoSiONo(act,id)
{
    $.ajax(
        {
            type: 'POST',
            dataType: 'JSON',
            url: '/Home/ObtenerUsuarioAjax',
            success:
            function (response)
            {
                if(response == null)
                {
                    $("#"+act+id).attr('data-bs-toggle','modal');
                    $("#"+act+id).attr('data-bs-target','#accesodenegado');
                }
                else
                {
                    switch(act)
                    {
                        case "like":
                            $("#"+act+id).attr('onclick','Likear('+id+','+response.id+')');
                            break;

                        case "coment":
                            $("#"+act+id).attr('data-bs-toggle','modal');
                            $("#"+act+id).attr('data-bs-target','#comentarios');
                            $("#"+act+id).attr('onclick','MostrarComentarios('+id+','+response.id+')');
                            break;
                    }
                }
            }
        }
    );
}

function LikeONo(idP,idU)
{
    $.ajax(
        {
            type: 'POST',
            dataType: 'JSON',
            url: '/Home/VerSiLikeAjax',
            data: { IdPost: idP, IdUser: idU },
            success:
                function (response)
                {
                    if(response)
                    {
                        $("#like"+idP).html("<img src='/likeon.png'>")
                    }
                    else
                    {
                        $("#like"+idP).html("<img src='/likeoff.png'>")
                    }
                }
        }
    );
}

function CantComentarios(id)
{
    $.ajax(
        {
            type: 'POST',
            dataType: 'JSON',
            url: '/Home/VerCantComentAjax',
            data: { IdPost: id },
            success:
                function (response)
                {
                    $("#cantcoment"+id).text(response);
                }
        }
    );
}

function CantLikes(id)
{
    $.ajax(
        {
            type: 'POST',
            dataType: 'JSON',
            url: '/Home/VerCantLikesAjax',
            data: { IdPost: id },
            success:
                function (response)
                {
                    $("#cantlikes"+id).text(response);
                }
        }
    );
}

function Likear(idP,idU)
{
    if($("#like"+idP).html() == "<img src=\"/likeon.png\">")
    {
        $("#like"+idP).html("<img src='/likeoff.png'>");
        $.ajax(
            {
                type: 'POST',
                dataType: 'JSON',
                url: '/Home/DeslikearAjax',
                data: { IdPost: idP, IdUser: idU },
                success:
                    function (response)
                    {
                        $("#cantlikes"+idP).text(response);
                    }
            }
        );
    }
    else
    {
        $("#like"+idP).html("<img src='/likeon.png'>");
        $.ajax(
            {
                type: 'POST',
                dataType: 'JSON',
                url: '/Home/LikearAjax',
                data: { IdPost: idP, IdUser: idU },
                success:
                    function (response)
                    {
                        $("#cantlikes"+idP).text(response);
                    }
            }
        );
    }
}

function Eliminar(id,act)
{
    if(act == "p")
    {
        $("#eliminartitulo").html("Eliminar publicación");
        $("#eliminarcontenido").html("<p class='text-center'>¿Estás seguro de que querés eliminar esta publicación?</p><a class='btn btn-danger opcionesperfil' href='/Home/EliminarPost?idPost=" + id + "'>Eliminar</a>");
    }
    else if(act == "c")
    {
        $("#eliminartitulo").html("Eliminar comentario");
        $("#eliminarcontenido").html("<p class='text-center'>¿Estás seguro de que querés eliminar este comentario?</p><a class='btn btn-danger opcionesperfil' href='/Home/EliminarComent?idComent=" + id + "'>Eliminar</a>");
    }
}
