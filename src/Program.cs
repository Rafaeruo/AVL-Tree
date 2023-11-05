// IDEIAS p/ alterar:
// - mudar arvore para segurar CHAVE e VALOR. Talvez usar uma classe wrapper por volta da pessoa q tenha o indice?
//      chave seria por exemplo NOME e valor seria o indice no array auxiliar
// - nao copiar as pessoas para o PessoaComIncide, usar o mesmo objeto e colocar o indice
// como valor da arvore
// - para a busca de data de nascimento, nao vou conseguir usar a busca que já temos (provavelmente)
// fazer uma busca com while, para encontrar a menor data de nascimento que seja maior que o limite
// inferior informado pelo usuário. Achando este, usa o index para percorrer o array.
// - para a busca por iniciais nao tenho ctz, tenho que avaliar se a tatica atual está ok.

using ArvoreAvl;
using ArvoreAvl.Csv;
using ArvoreAvl.Dados;
using ArvoreAvl.Operacoes;

var busca = new Busca<Pessoa>();
var edicao = new Edicao<Pessoa>(busca);
var percorrer = new Percorrer<Pessoa>();
var leitor = new LeitorCsv<Pessoa>(new MapeadorCsvPessoa());

new Menu(busca, edicao, percorrer, leitor).Iniciar();