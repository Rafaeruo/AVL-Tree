using ArvoreAvl;

var busca = new Busca();
var edicao = new Edicao(busca);
var percorrer = new Percorrer();

new Menu(busca, edicao, percorrer).Iniciar();