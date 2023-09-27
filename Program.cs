using ArvoreAvl;

var arvore = new Arvore(10)
{
    // Esquerda = new Arvore(2)
    // {
    //     Esquerda = new Arvore(1),
    //     Direita = new Arvore(3)
    // },
    // Direita = new Arvore(6)
    // {
    //     Esquerda = new Arvore(5),
    //     Direita = new Arvore(7)
    // },
};

var busca = new Busca();
var edicao = new Edicao(busca);

// arvore = edicao.Inserir(arvore, 2);
// arvore = edicao.Inserir(arvore, 3);
// arvore = edicao.Inserir(arvore, 6);
// arvore = edicao.Inserir(arvore, 7);
// arvore = edicao.Inserir(arvore, 505);
// arvore = edicao.Inserir(arvore, 10);
// arvore = edicao.Inserir(arvore, 5);
// // arvore = insercao.Inserir(arvore, 1723);
// // arvore = insercao.Inserir(arvore, 1823);
// // arvore = insercao.Inserir(arvore, 12938);
// // arvore = insercao.Inserir(arvore, 1723);
// // arvore = insercao.Inserir(arvore, 1238);
// // arvore = insercao.Inserir(arvore, 1283);
// // arvore = insercao.Inserir(arvore, 1223);
// // arvore = insercao.Inserir(arvore, 785);
// // arvore = insercao.Inserir(arvore, 38);
// // arvore = insercao.Inserir(arvore, 32);
// // arvore = insercao.Inserir(arvore, 39);
// // arvore = insercao.Inserir(arvore, 91);
// // arvore = insercao.Inserir(arvore, 371);
// // new Percorrer().EmOrdem(arvore);

// arvore.ExibirTabulacao();
// // arvore.ExibirGrafo();

// Console.WriteLine("");
// Console.WriteLine("Exclusao");
// Console.WriteLine("");

// arvore = edicao.Excluir(arvore, 505);
// arvore.ExibirTabulacao();
// Console.WriteLine();
// arvore = edicao.Excluir(arvore, 7);
// arvore.ExibirTabulacao();
// arvore.ExibirGrafo();

var percorrer = new Percorrer();
new Menu(busca, edicao, percorrer).Iniciar();