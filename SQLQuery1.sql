CREATE TABLE datamahasiswa (
  id int NOT NULL,
  name varchar (255) NOT NULL,
  email varchar(255) NOT NULL,
  NRP int NOT NULL DEFAULT 0,
  Batch int NOT NULL DEFAULT 0,
  Major varchar(255) NOT NULL,
);

--
-- Dumping data for table `datamahasiswa`
--

INSERT INTO datamahasiswa (id, name, email, NRP, Batch, Major) VALUES
(1, 'Martaka Endra Kurniawan', 'sitorus.opan@example.org', 50262296, 2020, 'Physics'),
(2, 'Titin Rahimah', 'mnovitasari@example.com', 50280619, 2019, 'Electrical Engineering'),
(3, 'Intan Yulia Suartini', 'hwibowo@example.org', 50291884, 2021, 'Infomation System'),
(4, 'Jayadi Arta Putra S.IP', 'bala16@example.com', 50289244, 2019, 'Computer Science'),
(5, 'Gambira Mansur S.Pt', 'elisa.prakasa@example.net', 50265969, 2021, 'Electrical Engineering'),
(6, 'Candra Tarihoran', 'siregar.jumadi@example.com', 50280139, 2019, 'Computer Engineering'),
(7, 'Hadi Ramadan', 'harjaya80@example.org', 50298459, 2019, 'Mathematics'),
(8, 'Fitria Laksita', 'ajeng.najmudin@example.com', 50298470, 2023, 'Physics'),
(9, 'Zulfa Carla Namaga', 'qadriansyah@example.com', 50275949, 2020, 'Infomation System'),
(10, 'Tirta Cahyadi Suryono M.M.', 'epratama@example.org', 50295703, 2020, 'Mathematics'),
(11, 'Sadina Pertiwi', 'pia.mulyani@example.net', 50258262, 2022, 'Physics'),
(12, 'Mahfud Rosman Permadi M.TI.', 'xpermata@example.net', 50268031, 2021, 'Computer Science'),
(13, 'Puspa Laksmiwati', 'yulianti.fitriani@example.com', 50281041, 2020, 'Electrical Engineering'),
(15, 'Argono Cahyadi Adriansyah', 'oni33@example.net', 50251223, 2021, 'Electrical Engineering'),
(16, 'AAA', 'eyuniar@example.org', 50275540, 2020, 'Electrical Engineering'),
(17, 'Darman Balidin Maryadi', 'hpermata@example.com', 50297356, 2021, 'Physics'),
(18, 'Gandi Pradipta', 'darijan.kurniawan@example.net', 50262463, 2020, 'Infomation System'),
(19, 'Wani Pratiwi', 'chelsea68@example.net', 50295072, 2020, 'Mathematics'),
(21, 'Nanda Vahindra', 'nandavahindra@mail.com', 50252002, 2021, 'Teknik Informatika');
 