--Llamados a las BD del "Numero de Asignaturas", "Nombres de las Asignaturas" y "Descripciones de las Asignaturas".

select * from Usuarios;

select * from UsuarioAsignatura;

select * from Asignaturas;

select u.Rut, u.Nombre, a.Nombre, a.Descripcion from Usuarios as u
inner join UsuarioAsignatura as ua on u.Rut = ua.RutUsuario
inner join Asignaturas as a on ua.CodAsignatura = a.CodAsig where u.Rut = '9334828';

select COUNT(a.CodAsig) from Usuarios as u
inner join UsuarioAsignatura as ua on u.Rut = ua.RutUsuario
inner join Asignaturas as a on ua.CodAsignatura = a.CodAsig where u.Rut = '9334828';

select  a.Nombre from Usuarios as u
inner join UsuarioAsignatura as ua on u.Rut = ua.RutUsuario
inner join Asignaturas as a on ua.CodAsignatura = a.CodAsig where u.Rut = '9334828';

select a.Descripcion from Usuarios as u
inner join UsuarioAsignatura as ua on u.Rut = ua.RutUsuario
inner join Asignaturas as a on ua.CodAsignatura = a.CodAsig where u.Rut = '9334828';