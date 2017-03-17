select * from Horarios as h 
INNER JOIN Asignaturas as a on h.CodAsignatura = a.CodAsig where h.CodAsignatura = 6;

select * from Horarios;

select * from Usuarios as u 
inner join UsuarioAsignatura as ua on u.Rut = ua.RutUsuario
inner join Asignaturas as a on ua.CodAsignatura = a.CodAsig
inner join Horarios as h on a.CodAsig = h.CodAsignatura where ua.Paralelo = h.Paralelo;

select u.Rut, u.Nombre, u.Apellidos, ua.CodAsignatura, ua.Semestre, ua.Paralelo, a.CodAsig, a.Nombre, h.Dia, h.CodHora, h.CodHoraFinal  from Usuarios as u 
inner join UsuarioAsignatura as ua on u.Rut = ua.RutUsuario 
inner join Asignaturas as a on ua.CodAsignatura = a.CodAsig
inner join Horarios as h on a.CodAsig = h.CodAsignatura where ua.Paralelo = h.Paralelo and u.Rut = '18300680';

select u.Nombre, u.Apellidos, a.Nombre, e.CodEdificios, s.CodSala from Usuarios as u 
inner join UsuarioAsignatura as ua on u.Rut = ua.RutUsuario
inner join Asignaturas as a on ua.CodAsignatura = a.CodAsig
inner join Horarios as h on a.CodAsig = h.CodAsignatura 
inner join Salas as s on  h.CodSala = s.CodSala
inner join Edificios as e on s.CodEdificio = e.CodEdificios
where ua.Paralelo = h.Paralelo and u.Rut = '18300680' and h.CodHora = '3' and h.Dia = '3';