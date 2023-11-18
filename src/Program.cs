using ArvoreAvl;
using ArvoreAvl.Comparadores;
using ArvoreAvl.Operacoes;

var busca = new Busca<int>();
var edicao = new Edicao<int>(busca);
var nodo = new Arvore<int>(1, new ComparadorInt());

nodo = edicao.Inserir(nodo, 10);
var nodoEncontrado = busca.Buscar(nodo, 10);
Console.WriteLine(nodoEncontrado);

var percorrer = new Percorrer<int>();
percorrer.PreOrdem(nodo);
