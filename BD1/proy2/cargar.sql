CREATE TABLE externa
        (
                a	varchar2(50),
                b	varchar2(50),
				c	varchar2(50),
				d	varchar2(50),
				e	varchar2(50),
				f	varchar2(50),
				g	varchar2(50),
				h	varchar2(50),
				i	varchar2(50),
				j	varchar2(50),
				k	varchar2(50),
				l	varchar2(50),
				m	varchar2(50),
				n	varchar2(50),
				o	varchar2(50),
				p	varchar2(50),
				q	varchar2(50),
				r	varchar2(50),
				s	varchar2(101),
				t	varchar2(101),
				u	varchar2(50),
				v	varchar2(50),
				w	varchar2(50),
				x	varchar2(50),
				y	varchar2(50),
				z	varchar2(55)
        )
        organization external
        (
                type oracle_loader
		DEFAULT directory ext_files
		access parameters
			( records delimited BY newline
			fields terminated BY ','
			missing field VALUES are NULL
			)
		location('entrada.csv')
        );