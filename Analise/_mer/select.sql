create database bd_cabelereiro;

use bd_cabelereiro;

create table tb_cliente(
	id_cliente					int primary key auto_increment,
    nm_cliente					varchar(75) not null,
    ds_cpf						varchar(15) not null,
    ds_cel_ou_tel				varchar(20) not null,
    ds_email					varchar(100) not null
);

create table tb_funcionario(
	id_funcionario				int primary key auto_increment,
	nm_funcionario				varchar(100) not null,
    ds_cargo					varchar(35) not null,
    dt_nascimento				date not null,
    ds_cpf						varchar(15) not null,
    ds_endereco					varchar(70) not null,
    ds_cep						varchar(11) not null,
    ds_complemento				varchar(20),
    ds_tel_ou_cel				varchar(20),
    ds_email					varchar(65) not null,
    dt_posse					date not null,
    dt_ult_feria				date,
    ds_foto						varchar(150),
    ds_curriculo				varchar(150) not null,
    nm_usuario					varchar(35) not null,
    ds_senha					varchar(8) not null
);

create table tb_agenda(
	id_agenda					int primary key auto_increment,
    id_funcionario				int,
    id_cliente					int,
    dt_agenda					datetime,
    foreign key (id_funcionario) references tb_funcionario (id_funcionario),
    foreign key (id_cliente) references tb_cliente (id_cliente)
);

create table tb_produto(
	id_produto					int primary key auto_increment,
    nm_produto					varchar(70),
    nm_marca					varchar(50),
    nr_codigo					int,
    vl_total					decimal(5, 2),
    dt_cadastro					datetime,
    dt_fabricacao				date,
    dt_vencimento				date,
    ds_nota_fiscal				varchar(100)
);

create table tb_estoque(
	id_estoque					int primary key auto_increment,
    id_produto					int,
    ds_motivo					varchar(50),
	qt_disponivel				int,
    dt_atualizacao				datetime,
    foreign key (id_produto) references tb_produto (id_produto)
);

CREATE TABLE tb_corte (
  `id_corte` INT primary key AUTO_INCREMENT,
  `id_funcionario` INT NOT NULL,
  `nm_corte` VARCHAR(70) NOT NULL,
  `tp_corte` VARCHAR(50) NOT NULL,
  `vl_corte` DECIMAL(3,2) NOT NULL,
  `id_produro` INT NOT NULL,
  `hr_preparo` TIME NULL,
  `ds_foto` VARCHAR(150) NULL,
  `ds_comentario` VARCHAR(70) NULL,
  `ds_dicas` VARCHAR(150) NULL,
  `dt_publicacao` DATETIME NULL,
  `vl_avaliacao` DECIMAL(2,2) NULL,
  foreign key (`id_funcionario`) references `tb_funcionario` ( `id_funcionario`)
);


create table tb_venda(
	id_venda					int primary key auto_increment,
    id_funcionario				int,
    id_cliente					int,
    id_corte					int,
    dt_venda					datetime,
    nm_cupom					int,
    dt_validade_cupom			date,
    vl_desconto_cupom			decimal(2, 2),
    foreign key (id_funcionario) references tb_funcionario (id_funcionario),
    foreign key (id_cliente) references tb_cliente (id_cliente),
	foreign key (id_corte) references tb_corte (id_corte)
);

create table tb_venda_produto(
	id_venda_produto			int primary key auto_increment,
    id_venda					int,
    id_produto					int,
    foreign key (id_venda) references tb_venda (id_venda),
    foreign key (id_produto) references tb_produto (id_produto)
);

create table tb_avaliacao_atendimento(
	id_avalicao					int primary key auto_increment,
    id_cliente					int,
    id_funcionario				int,
    id_corte					int,
	vl_funcionario				decimal(2, 2),
    vl_corte					decimal(2, 2),
    vl_estabelecimento			decimal(2, 2),
    ds_experiencia				varchar(255),
    foreign key (id_cliente) references tb_cliente (id_cliente),
    foreign key (id_funcionario) references tb_funcionario (id_funcionario),
    foreign key (id_corte) references tb_corte (id_corte)
);

	/*002.Corte*/
		select * 
		  from tb_corte						c
	inner join tb_funcionario				f
			on f.id_funcionario = c.id_funcionario
		 where nm_corte like '' 
		   and hr_preparo = '20:10' 
		   and dt_publicacao = '2020-05-05' 
		   and nm_funcionario like '' 
		   and tp_corte like '';
           
           /*PROT-002*/
           select nr_codigo, nm_produto, qt_disponivel
			 from tb_estoque			e
	   inner join tb_produto			p
			   on p.id_produto = e.id_produto;
               
               
               /*PROTP-002.Cliente*/
               select * 
                 from tb_cliente 
				where ds_cpf = '' 
                  and nm_cliente like '';             
                  
                  /*003.Cliente.ConsultaHorariodosClientes*/
                  select dt_agenda 
                    from tb_agenda				a
			  inner join tb_cliente				c
					  on c.id_cliente = a.id_cliente
				   where nm_cliente like '' and ds_cpf = '';
                  
           