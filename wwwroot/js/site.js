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
                    $("#comentariostitulo").html("Comentarios (" + response.Count + ")");
                    $("#comentarioscontenido").html("@{foreach(Comentario coment in " + response + "){<p>Temporada @temporada.NumeroTemporada - @temporada.TituloTemporada</p>}}");
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

                        case "add":
                            $("#"+act+id).attr('href','@Url.Action("AgregarPost","Home")');
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
            url: '/Home/VerLikesAjax',
            data: { IdPost: IdP },
            success:
                function (response)
                {
                    response.forEach(element => {
                        
                    });
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
                    $("#cantcoment"+id).text(response.Count);
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
                    $("#cantlikes"+id).text(response.Count);
                }
        }
    );
}

function Likear(idP,idU)
{

}
