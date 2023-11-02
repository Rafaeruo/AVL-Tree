using ArvoreAvl;

var busca = new Busca<int>();
var edicao = new Edicao<int>(busca);
var percorrer = new Percorrer<int>();

new Menu(busca, edicao, percorrer).Iniciar();