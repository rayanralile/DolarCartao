# DolarCartao
Dólar Cartão - cotação do seu roxinho. App para calcular o valor em reais que virá no cartão Nu ao efetuar uma compra em dólares americanos (USD).

## Introdução
Este APP foi criado usando o Visual Studio 2019, com a ferramenta Xamarim.Forms. Contém o PCL (Portable Class Library) e o projeto para Android.

## Fontes de Dados
Usei a API Olinda do Bacen para obter o dólar PTAX e as demais informações (Spread bancário e IOF) obtenho do meu próprio site, onde alimento o arquivo de texto com o valor
praticado.

## Regra de negócio do aplicativo
Ele calcula a cotação seguindo a regra abaixo:
- Obtém o valor em dólares americanos digitados pelo usuário
- Obtém o dólar PTAX
- Obtém spread e IOF do meu site (ralile.com.br) - no formato 1 + % (ex: 1.04 para 4%)
Calcula a cotação:
Cotacao <- USD_usuario * CotacaoPTAX * Spread * IOF

## Créditos
Além da API do Bacen, utilizei os ícones do Icon8.com - recomendo com empenho o seu uso. Os ícones são gratuitos e liberados para projetos OpenSource, e são gratuitos
com algumas limitações de tamanho e a necessidade de creditar a fonte nos aplicativos gratuitos (que não são OpenSource) e pagos. Veja mais informaçòes no próprio site.

## Publicar para iOS
Por ser feito no Xamarim.Forms, permite-se publicar para iOS. Para fazer, basta seguir os passos abaixo
1 - Criar um projeto iOS no solution do Visual Studio
2 - Adicionar as imagens no projeto do iOS, seguindo a notação da Apple (ex: About.png, About@2x.png e About@3x.png)
3 - Adicionar nas configurações do projeto que ele apenas aceita a orientação de retrato (fica distorcido o App se ele passa para a orientação paisagem)
4 - Adicionar sua chave de Apple Developer no projeto
5 - Exportar para o iPhone com a chave ou para a Apple Store
6 - Colocar os devidos créditos (meu nome e meu GitHub)

## Licença
Por falar em créditos, este App está licenciado pela "Atribuição 4.0 Internacional (CC BY 4.0)". Dessa forma, sinta-se a vontade para modificar o projeto e até mesmo
criar outros projetos tendo este como base, desde que haja a devida atribuição dos créditos, conforme descrito acima.

Espero que gostem do App :)
