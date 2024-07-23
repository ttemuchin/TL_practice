use HotelManagement

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Rooms')
	CREATE TABLE dbo.Rooms (
		room_id INT IDENTITY(1,1) NOT NULL,
		room_number INT NOT NULL,
		room_type NVARCHAR(50) NOT NULL,
		price_per_night NVARCHAR(50) NOT NULL,
		availability NVARCHAR(50) NOT NULL,
		CONSTRAINT PK_room_id PRIMARY KEY (room_id)
		)

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Customers')
	CREATE TABLE dbo.Customers (
		customer_id INT IDENTITY(1,1) NOT NULL,
		first_name NVARCHAR(50) NOT NULL,
		last_name NVARCHAR(50) NOT NULL,
		phone_number NVARCHAR(50) NOT NULL,
		email NVARCHAR(50) NOT NULL,
		CONSTRAINT PK_customer_id PRIMARY KEY (customer_id)
		)

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Bookings')
	CREATE TABLE dbo.Bookings (
		booking_id INT IDENTITY(1,1) NOT NULL,
		customer_id INT,
		room_id INT,
		check_in_date DATE NOT NULL,
		check_out_date DATE NOT NULL,
		CONSTRAINT PK_booking_id PRIMARY KEY (booking_id),
		FOREIGN KEY (customer_id) REFERENCES dbo.Customers(customer_id),
		FOREIGN KEY (room_id) REFERENCES dbo.Rooms(room_id)
		)

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Facilities')
	CREATE TABLE dbo.Facilities (
		facility_id INT IDENTITY(1,1) NOT NULL, 
		facility_name NVARCHAR(50) NOT NULL,
		CONSTRAINT PK_facility_id PRIMARY KEY (facility_id)
		)

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='RoomsToFacilities')
	CREATE TABLE dbo.RoomsToFacilities (
		room_id INT NOT NULL FOREIGN KEY REFERENCES dbo.Rooms(room_id),
		facility_id INT NOT NULL FOREIGN KEY REFERENCES dbo.Facilities(facility_id),
		PRIMARY KEY(room_id, facility_id)
		)

INSERT INTO dbo.Rooms(room_number, room_type, price_per_night, availability) VALUES (409, N'2-person', '2 USD', N'Ready')
INSERT INTO dbo.Rooms(room_number, room_type, price_per_night, availability) VALUES (420, N'3-person', N'8 USD', N'Ready')
INSERT INTO dbo.Rooms(room_number, room_type, price_per_night, availability) VALUES (420, N'4-person', N'10 USD', N'Busy')
INSERT INTO dbo.Rooms(room_number, room_type, price_per_night, availability) VALUES (404, N'5-person', N'---', N'Not Found')

INSERT INTO dbo.Customers(first_name, last_name, phone_number, email) VALUES (N'Ivan', N'Kirilov', N'89278796523', N'paketpaketov@gmail.com')
INSERT INTO dbo.Customers(first_name, last_name, phone_number, email) VALUES (N'Daniil', N'Gerasimov', N'89276658470', N'boss5536@gmail.com')
INSERT INTO dbo.Customers(first_name, last_name, phone_number, email) VALUES (N'Artem', N'Gradov', N'89271073032', N'mokoseev.artem@gmail.com')

INSERT INTO dbo.Bookings(customer_id, room_id, check_in_date, check_out_date) VALUES (1, 3, '2024-07-10','2024-08-03')
INSERT INTO dbo.Bookings(customer_id, room_id, check_in_date, check_out_date) VALUES (2, 2, '2024-07-01','2024-07-16')
INSERT INTO dbo.Bookings(customer_id, room_id, check_in_date, check_out_date) VALUES (3, 1, '2024-07-29','2024-08-01')
INSERT INTO dbo.Bookings(customer_id, room_id, check_in_date, check_out_date) VALUES (3, 2, '2024-08-04','2024-08-08')
INSERT INTO dbo.Bookings(customer_id, room_id, check_in_date, check_out_date) VALUES (3, 1, '2024-08-15','2024-08-20')


INSERT INTO dbo.Facilities(facility_name) VALUES ('royal towels')
INSERT INTO dbo.Facilities(facility_name) VALUES ('mini bar')
INSERT INTO dbo.Facilities(facility_name) VALUES ('breakfast to your bed')
INSERT INTO dbo.Facilities(facility_name) VALUES ('balcony')
INSERT INTO dbo.Facilities(facility_name) VALUES ('air cooler system')
INSERT INTO dbo.Facilities(facility_name) VALUES ('pets allowed')

INSERT INTO dbo.RoomsToFacilities(room_id, facility_id) VALUES (1,2)
INSERT INTO dbo.RoomsToFacilities(room_id, facility_id) VALUES (1,4)
INSERT INTO dbo.RoomsToFacilities(room_id, facility_id) VALUES (1,5)
INSERT INTO dbo.RoomsToFacilities(room_id, facility_id) VALUES (2,1)
INSERT INTO dbo.RoomsToFacilities(room_id, facility_id) VALUES (2,2)
INSERT INTO dbo.RoomsToFacilities(room_id, facility_id) VALUES (2,5)
INSERT INTO dbo.RoomsToFacilities(room_id, facility_id) VALUES (2,6)
INSERT INTO dbo.RoomsToFacilities(room_id, facility_id) VALUES (3,1)
INSERT INTO dbo.RoomsToFacilities(room_id, facility_id) VALUES (3,2)
INSERT INTO dbo.RoomsToFacilities(room_id, facility_id) VALUES (3,3)
INSERT INTO dbo.RoomsToFacilities(room_id, facility_id) VALUES (3,4)
INSERT INTO dbo.RoomsToFacilities(room_id, facility_id) VALUES (3,5)
INSERT INTO dbo.RoomsToFacilities(room_id, facility_id) VALUES (3,6)

--все доступные номера для бронирования сегодня
SELECT room_number FROM dbo.Rooms 
	WHERE availability = 'Ready';

--клиенты, чьи фамилии начинаются с буквы "G"
SELECT first_name, last_name FROM dbo.Customers 
	WHERE last_name LIKE 'G%';

--все бронирования для определенного клиента по электронному адресу
SELECT Bookings.booking_id, Customers.email 
	FROM Bookings JOIN Customers ON Bookings.customer_id = Customers.customer_id
		WHERE Customers.email = 'mokoseev.artem@gmail.com';

--все бронирования для определенного номера
SELECT Bookings.booking_id, Rooms.room_number 
	FROM Bookings JOIN Rooms ON Bookings.room_id = Rooms.room_id
		WHERE Rooms.room_number = '420';

--все номера, которые не забронированы на 28 июLя
DECLARE @the_day DATE;
SET @the_day = '2024-07-28';
SELECT Rooms.room_number, Bookings.check_in_date, Bookings.check_out_date
	FROM Rooms JOIN Bookings ON Bookings.room_id = Rooms.room_id
		WHERE Bookings.check_in_date > @the_day OR Bookings.check_out_date < @the_day;
