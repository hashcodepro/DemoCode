create table Users
(
	user_id serial primary key not null,
	email varchar(255) unique not null,
	firstName varchar(50),
	lastName varchar(50),
	registeredAt timestamp default now()
);

CREATE TABLE Address(
   address_id serial primary key not null,
   user_id int,
   address_line_1 varchar(255) not null,
   city varchar(50),
   postcode int,
   CONSTRAINT fk_Users
      FOREIGN KEY(user_id) 
	  REFERENCES Users(user_id)
	  ON DELETE CASCADE
);

create table Community
(
	community_id serial primary key not null,
	name varchar(100) not null
);

create table UserCommunity
(	
	id serial primary key not null,
	user_id int not null references Users(user_id),
	community_id int not null references Community(community_id)
);

insert into Users(email,firstName,lastName) values ('koko@gmail.com','Koko','Jon');
insert into Users(email,firstName,lastName) values ('dodo@gmail.com','Dodo','Jon');
insert into Users(email,firstName,lastName) values ('toto@gmail.com','Toto','Jon');
insert into Users(email,firstName,lastName) values ('jojo@gmail.com','Jojo','Jon');
insert into Users(email,firstName,lastName) values ('bobo@gmail.com','Bobo','Jon');

insert into Address(user_id,address_line_1,city,postcode) values(1,'A-403, Building 34','Thane','672800');
insert into Address(user_id,address_line_1,city,postcode) values(2,'B-503, Building 35','Thane','672801');
insert into Address(user_id,address_line_1,city,postcode) values(2,'C-603, Building 36','Thane','672802');
insert into Address(user_id,address_line_1,city,postcode) values(3,'D-703, Building 37','Thane','672803');
insert into Address(user_id,address_line_1,city,postcode) values(4,'E-803, Building 38','Thane','672804');

insert into Community(name) values ('Github');
insert into Community(name) values ('StackOverflow');
insert into Community(name) values ('LinkedIn');
insert into Community(name) values ('Docker');
insert into Community(name) values ('LInux');

insert into UserCommunity(user_Id,community_id) values(1,1);
insert into UserCommunity(user_Id,community_id) values(1,3);
insert into UserCommunity(user_Id,community_id) values(2,3);
insert into UserCommunity(user_Id,community_id) values(2,4);
insert into UserCommunity(user_Id,community_id) values(2,5);
insert into UserCommunity(user_Id,community_id) values(3,2);
insert into UserCommunity(user_Id,community_id) values(3,5);
insert into UserCommunity(user_Id,community_id) values(4,3);
insert into UserCommunity(user_Id,community_id) values(5,1);
insert into UserCommunity(user_Id,community_id) values(5,2);
insert into UserCommunity(user_Id,community_id) values(5,3);
insert into UserCommunity(user_Id,community_id) values(5,4);