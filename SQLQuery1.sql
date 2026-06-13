INSERT INTO Usuario 
    (Idusuario, Idtipo, Nombre, Dni, Sexo, Contraseña, Telefono, Correo, CreatedBy, CreatedAt)
VALUES
    (1,            -- Idusuario único que no exista aún
     1,            -- Idtipo = 1 (Admin)
     'Admin Principal',
     '00000000',
     'Masculino',
     'Admin1234',  -- Contraseña
     '999999999',
     'admin@cita.com',
     1,            -- CreatedBy (puede ser el mismo Idusuario en este primer registro)
     GETDATE());