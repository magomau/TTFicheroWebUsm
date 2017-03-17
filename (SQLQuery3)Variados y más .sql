select * from Usuarios;

select u.Nombre, u.Apellidos, a.Nombre from Usuarios as u 
inner join UsuarioAsignatura as ua on u.Rut = ua.RutUsuario
inner join Asignaturas as a on ua.CodAsignatura = a.CodAsig
inner join Horarios as h on a.CodAsig = h.CodAsignatura 
where u.Rut = '18300680';

select u.Nombre, u.Apellidos, a.Nombre from Usuarios as u 
inner join UsuarioAsignatura as ua on u.Rut = ua.RutUsuario
inner join Asignaturas as a on ua.CodAsignatura = a.CodAsig
inner join Horarios as h on a.CodAsig = h.CodAsignatura 
where u.Rut = '9334828';


select * from Asignaturas;
select * from Horarios where CodAsignatura = '9'  or CodAsignatura = '10' or CodAsignatura = '6' ;

select h.CodAsignatura, a.Nombre, h.Dia, h.CodHora, h.RutProfesor from Horarios as h
inner join Asignaturas as a on h.CodAsignatura = a.CodAsig
where RutProfesor = '9334828' and CodHora = '3' and Dia = '3' ;

select ua.RutUsuario, u.Nombre, u.Apellidos, a.Nombre, ua.Paralelo, ua.Nota1,ua.Nota2,ua.Nota3,ua.Nota4, ua.Nota5 from UsuarioAsignatura  as ua
inner join Usuarios as u on ua.RutUsuario = u.Rut
inner join Asignaturas as a on ua.CodAsignatura = a.CodAsig
where a.Nombre = 'DA1';

select * from UsuarioAsignatura;
select DISTINCT  ua.RutUsuario, u.Nombre, u.Apellidos, a.Nombre, ua.Paralelo, ua.Nota1,ua.Nota2,ua.Nota3,ua.Nota4, ua.Nota5 from Usuarios as u 
inner join UsuarioAsignatura as ua on u.Rut = ua.RutUsuario
inner join Asignaturas as a on a.CodAsig = ua.CodAsignatura
inner join Horarios as h on a.CodAsig = h.CodAsignatura
where a.Nombre = 'DA1' and h.RutProfesor = '9334828';

select DISTINCT  ua.RutUsuario, u.Nombre, u.Apellidos, a.Nombre, ua.Paralelo, ua.Nota1,ua.Nota2,ua.Nota3,ua.Nota4, ua.Nota5 from Usuarios as u 
inner join UsuarioAsignatura as ua on u.Rut = ua.RutUsuario
inner join Asignaturas as a on a.CodAsig = ua.CodAsignatura
inner join Horarios as h on a.CodAsig = h.CodAsignatura
where h.RutProfesor = '9334828';

select  ua.RutUsuario, u.Nombre, u.Apellidos, a.Nombre, ua.Paralelo, ua.Nota1,ua.Nota2,ua.Nota3,ua.Nota4, ua.Nota5 from Usuarios as u 
inner join UsuarioAsignatura as ua on u.Rut = ua.RutUsuario
inner join Asignaturas as a on a.CodAsig = ua.CodAsignatura
inner join Horarios as h on a.CodAsig = h.CodAsignatura
where h.RutProfesor = '9334828';

select* from Hora