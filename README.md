# Setup
Pour créer la base de données, lancer la solution.
Mettre à jour la base de donnée avec ef core

Installation package ef core
> dotnet tool install --global dotnet-ef

Se rendre dans le dossier de la solution API puis
> dotnet ef database update

Pour charger le csv dans la base de données, il existe un controller data sur l'api 

Charger les données csv
> POST api/data/initData

Truncate la base de données
> Post api/data/dropData

# Axes d'amélioration

- Possibilité d'ajouter des validateurs sur les différentes route API afin de vérifier si le contenu des requetes attendu est correct.
- Utiliser l'exception handler asp.net core au lieu de try catch pour gérer les exceptions. Pour ça qu'il n'y a pas de try catch dans l'API
- Ajout de log 
- Le get person par nom et prénom, passer par un identifiant externe autre que l'id en base (ex: propriété "reference")
- Middleware pour load la base de données avec le csv au startup de l'API ?
- Réponse de l'api en cas d'erreur
- Passer le chemin d'acces CSV dans le fichiers appsettings.json

# Point de blocage

- Génération auto d'un identifiant à mapper sur la partie contrat autre que l'id interne en base de donnée, créer un index ?
- Ecriture des tests autour de la classe de  "PersonService.cs" avec le db context, passer par un fake, mock le databasecontext, database en mémoire ?
- Test "PersonServiceTest.ShouldDeletePerson" fail quand tout les tests sont exécutés, je pensais qu'ajouter une collection pour jouer les test en séquentiel suffirait, mais non...
