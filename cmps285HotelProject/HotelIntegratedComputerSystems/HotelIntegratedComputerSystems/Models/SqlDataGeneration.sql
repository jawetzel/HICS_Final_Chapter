TRUNCATE TABLE Expenses1
TRUNCATE TABLE Bookings
TRUNCATE TABLE Rooms
TRUNCATE TABLE Buildings
TRUNCATE TABLE Customers

/*Buildings*/
insert into Buildings (Phone, Address, BuildingName) values (2253453456, '3200 Brook Ln, Hammond, La, 70706', 'Alpha');
insert into Buildings (Phone, Address, BuildingName) values (2253453478, '3205 Brook Ln, Hammond, La, 70706', 'Beta');
insert into Buildings (Phone, Address, BuildingName) values (2253453456, '3210 Brook Ln, Hammond, La, 70706', 'Chi');

/*Building 1 Rooms*/
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 1, '1A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 1, '1B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 1, '2A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 1, '2B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 1, '3A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 1, '3B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 1, '4A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 1, '4B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 1, '5A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 1, '5B', 1);

insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 2, '1A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 2, '1B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 2, '2A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 2, '2B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 2, '3A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 2, '3B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 2, '4A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 2, '4B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 2, '5A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 2, '5B', 1);

insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 3, '1A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 3, '1B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 3, '2A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 3, '2B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 3, '3A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 3, '3B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 3, '4A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 3, '4B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 3, '5A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (102, 1, 1, 3, '5B', 1);

/*Building 2 Rooms*/
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (103, 1, 1, 1, '1A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (103, 1, 1, 1, '1B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (103, 1, 1, 1, '2A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (103, 1, 1, 1, '2B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (103, 1, 1, 1, '3A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (103, 1, 1, 1, '3B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (103, 1, 1, 1, '4A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (103, 1, 1, 1, '4B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (103, 1, 1, 1, '5A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (103, 1, 1, 1, '5B', 1);

insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (103, 1, 1, 2, '1A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (103, 1, 1, 2, '1B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (103, 1, 1, 2, '2A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (103, 1, 1, 2, '2B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (103, 1, 1, 2, '3A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (103, 1, 1, 2, '3B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (103, 1, 1, 2, '4A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (103, 1, 1, 2, '4B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (103, 1, 1, 2, '5A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (103, 1, 1, 2, '5B', 1);

/*Building 3 Rooms*/
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (104, 1, 1, 1, '1A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (104, 1, 1, 1, '1B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (104, 1, 1, 1, '2A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (104, 1, 1, 1, '2B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (104, 1, 1, 1, '3A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (104, 1, 1, 1, '3B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (104, 1, 1, 1, '4A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (104, 1, 1, 1, '4B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (104, 1, 1, 1, '5A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (104, 1, 1, 1, '5B', 1);

insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (104, 1, 1, 2, '1A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (104, 1, 1, 2, '1B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (104, 1, 1, 2, '2A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (104, 1, 1, 2, '2B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (104, 1, 1, 2, '3A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (104, 1, 1, 2, '3B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (104, 1, 1, 2, '4A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (104, 1, 1, 2, '4B', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (104, 1, 1, 2, '5A', 1);
insert into Rooms(BuildingId, RoomTypeId, HousekeepingStatusId, FloorNumber, RoomNumber, RoomStatusId) values (104, 1, 1, 2, '5B', 1);


/*Customers*/
insert into Customers (Name, Address, Phone, Email) values ('Marilyn Peterson', '91366 Sundown Point', 3191486585, 'mpeterson0@uol.com.br');
insert into Customers (Name, Address, Phone, Email) values ('Joshua Patterson', '776 Forest Dale Circle', 8385613749, 'jpatterson1@cornell.edu');
insert into Customers (Name, Address, Phone, Email) values ('Christine Larson', '60757 Ryan Street', 3845737151, 'clarson2@redcross.org');
insert into Customers (Name, Address, Phone, Email) values ('Michael Hunter', '321 Anhalt Crossing', 1247642733, 'mhunter3@ycombinator.com');
insert into Customers (Name, Address, Phone, Email) values ('Juan Smith', '2 Loomis Pass', 9591617858, 'jsmith4@phpbb.com');
insert into Customers (Name, Address, Phone, Email) values ('Joyce Graham', '30 Marquette Hill', 6857010341, 'jgraham5@buzzfeed.com');
insert into Customers (Name, Address, Phone, Email) values ('Roger Mills', '55736 Anthes Drive', 1217968410, 'rmills6@ask.com');
insert into Customers (Name, Address, Phone, Email) values ('Wanda Lopez', '426 Mifflin Street', 3527766035, 'wlopez7@usa.gov');
insert into Customers (Name, Address, Phone, Email) values ('Maria Lee', '2 Everett Alley', 1335026040, 'mlee8@tripod.com');
insert into Customers (Name, Address, Phone, Email) values ('Jessica Nguyen', '226 Cambridge Avenue', 9085471996, 'jnguyen9@nps.gov');
insert into Customers (Name, Address, Phone, Email) values ('Howard Williams', '67371 Park Meadow Point', 5667113715, 'hwilliamsa@zdnet.com');
insert into Customers (Name, Address, Phone, Email) values ('Christine Evans', '064 Crowley Park', 1185744249, 'cevansb@deliciousdays.com');
insert into Customers (Name, Address, Phone, Email) values ('Diana Hall', '9284 Prentice Plaza', 1518722388, 'dhallc@ox.ac.uk');
insert into Customers (Name, Address, Phone, Email) values ('Raymond Cooper', '426 Eagan Drive', 8993660429, 'rcooperd@woothemes.com');
insert into Customers (Name, Address, Phone, Email) values ('Bonnie Sims', '5970 Sachtjen Parkway', 9049964627, 'bsimse@mit.edu');
insert into Customers (Name, Address, Phone, Email) values ('Martin Thomas', '0 Thompson Court', 5494869129, 'mthomasf@4shared.com');
insert into Customers (Name, Address, Phone, Email) values ('Daniel Howard', '06 North Junction', 1064220484, 'dhowardg@yolasite.com');
insert into Customers (Name, Address, Phone, Email) values ('Russell Snyder', '00 Springview Alley', 1448749969, 'rsnyderh@eepurl.com');
insert into Customers (Name, Address, Phone, Email) values ('Nicholas Russell', '29175 Westerfield Park', 6147715811, 'nrusselli@webnode.com');
insert into Customers (Name, Address, Phone, Email) values ('Julie Daniels', '2 Corry Drive', 6776960503, 'jdanielsj@reverbnation.com');
insert into Customers (Name, Address, Phone, Email) values ('Donna Hanson', '35106 Lindbergh Circle', 9954110498, 'dhansonk@forbes.com');
insert into Customers (Name, Address, Phone, Email) values ('John Carpenter', '167 Blaine Point', 8524944608, 'jcarpenterl@sun.com');
insert into Customers (Name, Address, Phone, Email) values ('Daniel Robinson', '5822 Emmet Crossing', 8657668516, 'drobinsonm@discovery.com');
insert into Customers (Name, Address, Phone, Email) values ('Rose Lewis', '49 Summer Ridge Road', 8490431513, 'rlewisn@t.co');
insert into Customers (Name, Address, Phone, Email) values ('Mildred Shaw', '4722 Mesta Pass', 5229835262, 'mshawo@theglobeandmail.com');
insert into Customers (Name, Address, Phone, Email) values ('Harry Black', '554 Mallard Junction', 1662780874, 'hblackp@vistaprint.com');
insert into Customers (Name, Address, Phone, Email) values ('Michael Arnold', '25829 Pearson Pass', 1082254426, 'marnoldq@java.com');
insert into Customers (Name, Address, Phone, Email) values ('Patrick Dixon', '1 Birchwood Terrace', 3583019825, 'pdixonr@github.com');
insert into Customers (Name, Address, Phone, Email) values ('Margaret Welch', '1700 Northland Hill', 2280585809, 'mwelchs@redcross.org');
insert into Customers (Name, Address, Phone, Email) values ('Howard Lynch', '1 Messerschmidt Junction', 9114501623, 'hlyncht@ocn.ne.jp');
insert into Customers (Name, Address, Phone, Email) values ('Jose Stewart', '6 Sachtjen Park', 9664735895, 'jstewartu@skyrock.com');
insert into Customers (Name, Address, Phone, Email) values ('Debra Murphy', '26 Arapahoe Trail', 3918932872, 'dmurphyv@discovery.com');
insert into Customers (Name, Address, Phone, Email) values ('Joseph Wood', '6 Maywood Park', 2052741036, 'jwoodw@free.fr');
insert into Customers (Name, Address, Phone, Email) values ('Lois Romero', '3624 Veith Point', 8981997600, 'lromerox@over-blog.com');
insert into Customers (Name, Address, Phone, Email) values ('Antonio Ferguson', '15 Express Center', 5662472654, 'afergusony@dagondesign.com');
insert into Customers (Name, Address, Phone, Email) values ('Ashley Scott', '664 Sunfield Circle', 7804202969, 'ascottz@blogtalkradio.com');
insert into Customers (Name, Address, Phone, Email) values ('Phillip Sanchez', '71 Colorado Alley', 6404426666, 'psanchez10@princeton.edu');
insert into Customers (Name, Address, Phone, Email) values ('Willie Snyder', '429 Pine View Place', 7642008084, 'wsnyder11@drupal.org');
insert into Customers (Name, Address, Phone, Email) values ('Johnny Ortiz', '24 Nelson Hill', 8182245688, 'jortiz12@wikipedia.org');
insert into Customers (Name, Address, Phone, Email) values ('Victor Garrett', '067 Claremont Circle', 2021346096, 'vgarrett13@europa.eu');
insert into Customers (Name, Address, Phone, Email) values ('Sharon Nichols', '0453 Marquette Street', 3858190207, 'snichols14@aboutads.info');
insert into Customers (Name, Address, Phone, Email) values ('Richard Rivera', '1 Service Road', 5392661689, 'rrivera15@icq.com');
insert into Customers (Name, Address, Phone, Email) values ('Martha Gonzalez', '97 Manitowish Center', 1296606445, 'mgonzalez16@de.vu');
insert into Customers (Name, Address, Phone, Email) values ('Todd Peters', '38 Monument Point', 3406169490, 'tpeters17@sogou.com');
insert into Customers (Name, Address, Phone, Email) values ('Aaron Cunningham', '43 Reindahl Point', 1121263118, 'acunningham18@home.pl');
insert into Customers (Name, Address, Phone, Email) values ('Kevin Reynolds', '99 Thompson Road', 8337004607, 'kreynolds19@umn.edu');
insert into Customers (Name, Address, Phone, Email) values ('Lisa Nguyen', '5687 Arkansas Circle', 9072766994, 'lnguyen1a@sitemeter.com');
insert into Customers (Name, Address, Phone, Email) values ('Matthew Perry', '2 Esch Road', 6357379165, 'mperry1b@topsy.com');
insert into Customers (Name, Address, Phone, Email) values ('Brenda Ward', '3 Scott Terrace', 5288493223, 'bward1c@bluehost.com');
insert into Customers (Name, Address, Phone, Email) values ('John Allen', '03 Sloan Plaza', 4468764451, 'jallen1d@bravesites.com');
insert into Customers (Name, Address, Phone, Email) values ('Scott Davis', '727 Judy Alley', 1912786265, 'sdavis1e@opera.com');
insert into Customers (Name, Address, Phone, Email) values ('Theresa Brown', '644 Blaine Street', 9733355608, 'tbrown1f@rambler.ru');
insert into Customers (Name, Address, Phone, Email) values ('Louis Harvey', '715 Kim Lane', 3458808450, 'lharvey1g@huffingtonpost.com');
insert into Customers (Name, Address, Phone, Email) values ('Louise Patterson', '85949 Iowa Lane', 7992551711, 'lpatterson1h@ca.gov');
insert into Customers (Name, Address, Phone, Email) values ('Mildred Franklin', '9361 Miller Circle', 1205382022, 'mfranklin1i@forbes.com');
insert into Customers (Name, Address, Phone, Email) values ('Benjamin Bailey', '0318 Hovde Way', 5563413578, 'bbailey1j@rambler.ru');
insert into Customers (Name, Address, Phone, Email) values ('Rachel Martin', '07748 Nelson Park', 6374255131, 'rmartin1k@patch.com');
insert into Customers (Name, Address, Phone, Email) values ('Judith Hansen', '24887 Express Road', 2034895606, 'jhansen1l@pagesperso-orange.fr');
insert into Customers (Name, Address, Phone, Email) values ('Wanda Perkins', '47566 Division Junction', 2954920406, 'wperkins1m@discuz.net');
insert into Customers (Name, Address, Phone, Email) values ('Cynthia Harper', '3 Cody Trail', 7083825104, 'charper1n@japanpost.jp');
insert into Customers (Name, Address, Phone, Email) values ('Kenneth Reynolds', '98 Schmedeman Avenue', 9685330814, 'kreynolds1o@washington.edu');
insert into Customers (Name, Address, Phone, Email) values ('Doris Chavez', '5 Toban Drive', 1730151559, 'dchavez1p@buzzfeed.com');
insert into Customers (Name, Address, Phone, Email) values ('Deborah Washington', '243 Kingsford Junction', 1839667722, 'dwashington1q@sogou.com');
insert into Customers (Name, Address, Phone, Email) values ('William Sanchez', '68264 Ramsey Road', 7497541644, 'wsanchez1r@jimdo.com');
insert into Customers (Name, Address, Phone, Email) values ('Brandon Garrett', '3959 Vahlen Avenue', 6000106742, 'bgarrett1s@ovh.net');
insert into Customers (Name, Address, Phone, Email) values ('Frank Banks', '8 Harper Trail', 3899186872, 'fbanks1t@webmd.com');
insert into Customers (Name, Address, Phone, Email) values ('Angela Martin', '6 Pond Crossing', 9858975693, 'amartin1u@cargocollective.com');
insert into Customers (Name, Address, Phone, Email) values ('Jennifer Smith', '8254 Eagle Crest Avenue', 7204833182, 'jsmith1v@wired.com');
insert into Customers (Name, Address, Phone, Email) values ('Victor Ferguson', '0090 Redwing Center', 1100696520, 'vferguson1w@unblog.fr');
insert into Customers (Name, Address, Phone, Email) values ('Russell Woods', '3 Sachtjen Street', 4227337112, 'rwoods1x@xrea.com');
insert into Customers (Name, Address, Phone, Email) values ('Wayne Oliver', '14030 5th Road', 9871022714, 'woliver1y@redcross.org');
insert into Customers (Name, Address, Phone, Email) values ('Teresa Montgomery', '98008 Larry Plaza', 1488545677, 'tmontgomery1z@i2i.jp');
insert into Customers (Name, Address, Phone, Email) values ('Robin Thompson', '4 Fairview Street', 5459729127, 'rthompson20@a8.net');
insert into Customers (Name, Address, Phone, Email) values ('Janet Frazier', '13 Ryan Hill', 8300055097, 'jfrazier21@weibo.com');
insert into Customers (Name, Address, Phone, Email) values ('Marie Duncan', '1517 Beilfuss Lane', 3997462631, 'mduncan22@jimdo.com');
insert into Customers (Name, Address, Phone, Email) values ('Douglas Chavez', '31118 Chive Terrace', 3653411004, 'dchavez23@biglobe.ne.jp');
insert into Customers (Name, Address, Phone, Email) values ('Diana Woods', '0 Kenwood Hill', 2366487355, 'dwoods24@de.vu');
insert into Customers (Name, Address, Phone, Email) values ('Jack Carroll', '322 Cody Hill', 6902232271, 'jcarroll25@baidu.com');
insert into Customers (Name, Address, Phone, Email) values ('Kenneth Mills', '861 Lien Hill', 2263113374, 'kmills26@ucla.edu');
insert into Customers (Name, Address, Phone, Email) values ('Douglas Collins', '41 Boyd Trail', 3341338960, 'dcollins27@ebay.com');
insert into Customers (Name, Address, Phone, Email) values ('Nancy Elliott', '8 Sunnyside Road', 1630865183, 'nelliott28@quantcast.com');
insert into Customers (Name, Address, Phone, Email) values ('Philip Fowler', '074 Kensington Center', 9164944460, 'pfowler29@booking.com');
insert into Customers (Name, Address, Phone, Email) values ('George Burke', '7671 Maple Wood Place', 6447196289, 'gburke2a@purevolume.com');
insert into Customers (Name, Address, Phone, Email) values ('Henry Howard', '124 Evergreen Parkway', 4238223404, 'hhoward2b@prweb.com');
insert into Customers (Name, Address, Phone, Email) values ('Lillian Palmer', '2351 Sauthoff Junction', 3802160344, 'lpalmer2c@hugedomains.com');
insert into Customers (Name, Address, Phone, Email) values ('Lawrence Edwards', '85 Harper Way', 6214176033, 'ledwards2d@tripadvisor.com');
insert into Customers (Name, Address, Phone, Email) values ('Richard Larson', '44 Hudson Pass', 1235832610, 'rlarson2e@usnews.com');
insert into Customers (Name, Address, Phone, Email) values ('Sharon Cunningham', '8687 Loomis Way', 1179035679, 'scunningham2f@princeton.edu');
insert into Customers (Name, Address, Phone, Email) values ('Teresa Gibson', '742 Dunning Parkway', 5635086118, 'tgibson2g@discuz.net');
insert into Customers (Name, Address, Phone, Email) values ('Aaron Hawkins', '77 Hansons Drive', 6589524176, 'ahawkins2h@wsj.com');
insert into Customers (Name, Address, Phone, Email) values ('Anna Thompson', '3 Gerald Parkway', 3519594626, 'athompson2i@domainmarket.com');
insert into Customers (Name, Address, Phone, Email) values ('Nancy Burns', '332 4th Crossing', 5047861688, 'nburns2j@eepurl.com');
insert into Customers (Name, Address, Phone, Email) values ('Kevin Wells', '54 Dennis Place', 1863516613, 'kwells2k@fda.gov');
insert into Customers (Name, Address, Phone, Email) values ('Debra Harper', '238 Red Cloud Junction', 5522756646, 'dharper2l@cnet.com');
insert into Customers (Name, Address, Phone, Email) values ('Doris Hall', '714 John Wall Road', 7210244109, 'dhall2m@go.com');
insert into Customers (Name, Address, Phone, Email) values ('Margaret Hawkins', '013 Memorial Street', 5162992531, 'mhawkins2n@msn.com');
insert into Customers (Name, Address, Phone, Email) values ('Patrick Reid', '03637 Debra Terrace', 1576531669, 'preid2o@mail.ru');
insert into Customers (Name, Address, Phone, Email) values ('Ashley White', '59 Graceland Avenue', 6067785158, 'awhite2p@issuu.com');
insert into Customers (Name, Address, Phone, Email) values ('Nicole Hudson', '3 Becker Point', 1832631771, 'nhudson2q@stanford.edu');
insert into Customers (Name, Address, Phone, Email) values ('Rose Ellis', '25738 Bayside Junction', 9199285254, 'rellis2r@constantcontact.com');


/*Bookings*/
insert into Bookings(CustomerId, RoomId, StartDate, EndDate, VolumeAdults, VolumeChildren, BookingStatusId, CheckedInDate, CheckedOutDate) values (1, 2);





