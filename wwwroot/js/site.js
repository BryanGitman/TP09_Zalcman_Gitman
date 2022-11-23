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

function MostrarComentarios(IdP)
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
                    if(response != null)
                    {
                        $("#comentariostitulo").html("Comentarios (" + response.Count + ")");
                        var content = "";
                        response.forEach(element => {
                            content += "<div class='row dataPost coment'><div class='circulo'><img src='/" + element.FotoPerfil + "' id='imagenC" + element.ID + "'><script>HorizontalOVertical('imagenC" + element.ID + "');</script></div><div class='col-sm-9'><div class='user'><p><b>" + element.NombreUsuario + "</b></p><p class='text-muted'>de " + element.PaisOrigen + "</p></div><p>" + element.Contenido + "</p><p class='text-muted derecha'>" + element.FechaComentario.ToShortDateString() + "</p></div></div>";
                        });
                        content += "<footer><form method='post' action='@Url.Action('GuardarComentario','Home')'><input type='text' name='Contenido' class= 'agcoment' placeholder ='Agregá un comentario'><input type='hidden' name='IDUsuario' value='@ViewBag.usuario.ID'><input type='hidden' name='FechaComentario' value='@DateTime.Now'><input type='hidden' name='IDPublicacion' value='" + idP + "'><input type='submit' class='btn btn-primary' value = 'Publicar'></form></footer>";
                        $("#comentarioscontenido").html(content);
                    }
                    else
                    {
                        $("#comentariostitulo").html("Comentarios (0)");
                        var content = "No hay comentarios aún. Sé el primero en comentar"
                        content += "<footer><form method='post' action='@Url.Action('GuardarComentario','Home')'><input type='text' name='Contenido' class= 'agcoment' placeholder ='Agregá un comentario'><input type='hidden' name='IDUsuario' value='@ViewBag.usuario.ID'><input type='hidden' name='FechaComentario' value='@DateTime.Now'><input type='hidden' name='IDPublicacion' value='" + idP + "'><input type='submit' class='btn btn-primary' value = 'Publicar'></form></footer>";
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
                $("#foto").html("<img src='/"+ response.FotoPerfil + "' id='imagen" + response.ID + "'><script>HorizontalOVertical('imagen" + response.ID + "');</script>");
                $("#nombreusuario").text(response.NombreUsuario);
                $("#mispublicaciones").attr('href','@Url.Action("Home","Home",new {idUser = ' + response.ID + ', idDest = 0})');
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
                            $("#"+act+id).attr('onclick','Likear('+id+','+response.ID+')');
                            break;

                        case "coment":
                            $("#"+act+id).attr('data-bs-toggle','modal');
                            $("#"+act+id).attr('data-bs-target','#comentarios');
                            $("#"+act+id).attr('onclick','MostrarComentarios('+id+')');
                            break;
                    }
                }
            }
        }
    );
}

function LikeONo(idP,user)
{
    $.ajax(
        {
            type: 'POST',
            dataType: 'JSON',
            url: '/Home/VerLikesAjax',
            data: { IdPost: idP },
            success:
                function (response)
                {
                    var like = false;
                    if(user != null)
                    {
                        response.forEach(element => {
                            if(element == user.ID)
                            {
                                like = true;
                            }
                        });
                    }
                    if(like)
                    {
                        $("#like"+idP).html("<img id='l"+idP+"' src='/likeon.png'>")
                    }
                    else
                    {
                        $("#like"+idP).html("<img id='l"+idP+"' src='/likeoff.png'>")
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
            url: '/Home/VerComentariosAjax',
            data: { IdPost: IdP },
            success:
                function (response)
                {
                    if(response != null)
                    {
                        $("#cantcoment"+id).text(response.Count);
                    }
                    else
                    {
                        $("#cantcoment"+id).text("0");
                    }
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
            url: '/Home/VerLikesAjax',
            data: { IdPost: IdP },
            success:
                function (response)
                {
                    if(response != null)
                    {
                        $("#cantlikes"+id).text(response.Count);
                    }
                    else
                    {
                        $("#cantlikes"+id).text("0");
                    }
                }
        }
    );
}

function Likear(idP,idU)
{
    if($("#l"+idP).src == "/likeoff.png")
    {
        $("#l"+idP).src == "/likeon.png"
    }
    else
    {
        $("#l"+idP).src == "/likeoff.png"
    }
}
