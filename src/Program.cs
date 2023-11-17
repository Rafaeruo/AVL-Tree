// Autores:
// Rafael Scholz Griebler
// Andryll Rafael da Silva
// Patrique Schwanck Rodrigues

using ArvoreAvl;
using ArvoreAvl.Csv;
using ArvoreAvl.Dados;
using ArvoreAvl.Operacoes;

var busca = new Busca<Pessoa>();
var edicao = new Edicao<Pessoa>(busca);
var leitor = new LeitorCsv<Pessoa>(new MapeadorCsvPessoa());

new Menu(busca, edicao, leitor).Iniciar();