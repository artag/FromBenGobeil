# Learning Paket

## Why Paket

1. Управление версиями NuGet пакетов для всех projects во всем solution.
Синхронизация версий пакетов между всеми проектами.

2. Управление версиями дочерних NuGet пакетов во всем solution..

3. Package paths/F# Interactive integration. Упрощение указания пути к пакету
(нет зависимости пути от версии NuGet пакета, упрощение загрузки пакетов в F# скриптах).

4. Возможность ссылаться напрямую на исходники (например на исходники в Github).

5. Можно управлять Paket через CLI и IDE.

## Practice. Инициализация Paket

1. Create new solution

```text
dotnet new sln
```

2. Create template "Dotnet local tool manifest file" (где .sln файл)

```text
dotnet new tool-manifest
```

Создает `.config/dotnet-tools.json`.

Don't forget to commit `dotnet-tools.json` to your source control.

3. Установка Paket

Установка locally (показано в видео)

```text
dotnet tool install paket
```

Установка globally (можно так)

```text
dotnet tool install --global Paket
```

В `dotnet-tools.json` прописывается paket.

5. Создание консольного проекта на F#


6. Инициализация Paket

**Не рекомендуется** использовать, т.к. в проекты не добавляется поддержка paket.

Create an empty `paket.dependencies` file in the current working directory.

```text
dotnet paket init
```

Вместо этого **рекомендуется** использовать

```text
dotnet paket convert-from-nuget
```

В корень sloution добавляются файлы:

* `paket.dependencies`
* `paket.lock`

С используемыми nuget пакетами с указанием версии.

В проект добавляется файл `paket.references`, в сам файл проекта добавляется ссылка на paket.

## Scheme

```text
Solution root:                   Projects:

packet.dependencies
                            --- paket.references
    |         |             |
 Install    Update          |
    |         |             |
                    refers  |
    packet.lock  -------------- paket.references
                    Restore
```

Команды:

* *Restore* - look in `paket.lock` for packages (download if needed), update version in
`.fsproj` files (if applicable).

* *Install* - grab defined dependencies from `paket.dependencies` and resolve them in
`paket.lock` (DOES NOT UPDATE VERSIONS IF ALREADY IN LOCK FILE)

* *Update* - do install (see above) but update versions (IF APPLICABLE)

## Practice. Добавление пакета

1. Добавление пакета в проект

```text
dotnet paket add FSharpPlus
```

Такая команда просто добавит пакет в солюшен, но не в проект - этого нам не надо.

Лучше так - добавление nuget пакета в интерактивном режиме:

```text
dotnet paket add FSharpPlus -i
```

### Какие файлы commit'ить

* `dotnet-tools.json`
* `paket.dependencies`, where you specify your dependencies and their versions for your
entire codebase.
* `paket.references`, a file that specifies a subset of your dependencies for every project
in a solution.
* `paket.lock`, a lock file that Paket generates when it runs. When you check it into source
control, you get reproducible builds.
