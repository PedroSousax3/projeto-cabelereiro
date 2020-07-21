CREATE DATABASE `bd_cabelereiro`; 

USE `bd_cabelereiro`;

CREATE TABLE `bd_cabelereiro`.`tb_funcionario` (
		`id_funcionario` INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
		`nm_funcionario` VARCHAR(100) NOT NULL,
		`tp_cargo` VARCHAR(35) NOT NULL,
		`dt_nascimento` DATETIME NOT NULL,
		`ds_cpf` VARCHAR(15) NOT NULL,
		`ds_endereco` VARCHAR(70) NOT NULL,
		`ds_cep` VARCHAR(11) NOT NULL,
		`ds_complemento` VARCHAR(20) NULL,
		`ds_tel` VARCHAR(20) NOT NULL,
		`ds_email` VARCHAR(65) NOT NULL,
		`dt_posse` DATE NOT NULL,
		`ds_foto` VARCHAR(150) NULL,
		`ds_curriculo` VARCHAR(150) NOT NULL,
		`nm_usuario` VARCHAR(35) NOT NULL,
		`ds_senha` VARCHAR(12) NOT NULL
  );
  
CREATE TABLE `bd_cabelereiro`.`tb_cliente` (
		`id_cliente` INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
		`nm_cliente` VARCHAR(75) NOT NULL,
		`ds_cpf` VARCHAR(15) NOT NULL,
        `dt_nascimento` DATE,
		`ds_tel` VARCHAR(20) NOT NULL,
		`ds_email` VARCHAR(100) NOT NULL
  );
  
  CREATE TABLE `tb_agenda` (
		`id_agenda` INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
		`id_funcionario` INT NOT NULL,
		`id_cliente` INT NOT NULL,
		`dt_corte` DATETIME NOT NULL,
		FOREIGN KEY (`id_funcionario`) REFERENCES `tb_funcionario` (`id_funcionario`) ON DELETE CASCADE,
		FOREIGN KEY (`id_cliente`) REFERENCES `tb_cliente` (`id_cliente`) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS `bd_cabelereiro`.`tb_corte` (
		`id_corte` INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
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
		FOREIGN KEY (`id_funcionario`) REFERENCES `tb_funcionario` (`id_funcionario`) ON DELETE CASCADE
);

CREATE TABLE `tb_venda` (
		`id_venda` INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
		`id_funcionario` INT NOT NULL,
		`id_cliente` INT NOT NULL,
		`id_corte` INT NOT NULL,
		`dt_venda` DATETIME NOT NULL,
		`nm_cupom` INT NULL,
		`dt_validade_cupom` DATE NULL,
		`vl_desconto_cupom` DECIMAL(5) NULL,
		FOREIGN KEY (`id_funcionario`) REFERENCES `tb_funcionario` (`id_funcionario`) ON DELETE CASCADE,
		FOREIGN KEY (`id_cliente`) REFERENCES `tb_cliente` (`id_cliente`) ON DELETE CASCADE,
		FOREIGN KEY (`id_corte`) REFERENCES `tb_corte` (`id_corte`) ON DELETE CASCADE
);

CREATE TABLE `tb_produto` (
		`id_produto` INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
		`nm_produto` VARCHAR(70) NOT NULL,
		`nm_marca` VARCHAR(50) NULL,
		`vl_compra` DECIMAL(10) NOT NULL,
		`vl_total` DECIMAL(10) NOT NULL,
		`dt_cadastro` DATE NOT NULL,
		`dt_fabricacao` DATE NULL,
		`ds_unidade_medida` VARCHAR(45) NOT NULL,
		`dt_vencimento` DATE NOT NULL,
		`ds_nota_fical` VARCHAR(100) NOT NULL
);

CREATE TABLE `tb_estoque` (
		`id_estoque` INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
		`id_venda` INT NOT NULL,
		`id_produto` INT NOT NULL,
		`ds_motivo` VARCHAR(65) NOT NULL,
		`qt_disponivel` INT NOT NULL,
		`dt_atualizacao` DATETIME NOT NULL,
		FOREIGN KEY (`id_produto`) REFERENCES `tb_produto` (`id_produto`),
		FOREIGN KEY (`id_venda`) REFERENCES `tb_venda` (`id_venda`)
);