## Název projektu

HR systém pro správu zaměstnanců, docházky a personalistických procesů.

## Účel tohoto souboru

Tento soubor definuje pravidla pro AI asistenty (Claude / Cursor apod.), aby:
- udržovaly jednotný styl kódu,
- respektovaly architekturu projektu,
- neprováděly nebezpečné nebo destruktivní změny.

---

### 1. Technologický stack

- **Backend**: .NET C#, ASP.NET Core
- **Frontend**: Blazor
- **Databáze**: MS SQL, EF Core
- **Build & tooling**: dotnet CLI

Pokud AI navrhuje nové řešení, má **preferovat tento stack** a vyhýbat se jiným technologiím, pokud to není výslovně požadováno.

---

### 2. Styl kódu

- **Jazyk komentářů**: angličtinu
- **C#**:
  - používat `async/await` kde dává smysl,
  - dodržovat pojmenování PascalCase pro třídy a metody, camelCase pro lokální proměnné,
  - nepřidávat zbytečné komentáře typu „// metoda vrací…“ – komentovat jen nejasnou logiku a záměr.
- **Frontend** (pokud je):
  - používat funkcionální komponenty,
  - stav držet co nejníže, složitější stav v globálním store,
  - nepoužívat `any` v TypeScriptu, pokud to není nutné.

AI má **respektovat existující styl v repozitáři** – pokud se liší od těchto pravidel, přednost má reálný kód.

---

### 3. Architektura a struktura projektu

- **Rozvržení složek**:
  - `Domain` – doménové modely a logika
  - `Application` – use-cases / služby
  - `Infrastructure` – přístup k DB, integrace
  - `Web` / `Api` – kontrolery, endpointy
- Nový kód:
  - doménová logika patří do `Domain`/`Application`, **ne** do kontrolerů,
  - kontrolery mají být tenké – validace + volání služeb.

AI nesmí vytvářet nové architektonické vrstvy bez důvodu, má se držet existující struktury.

---

### 4. Práce s daty a bezpečnost

- Nikdy nelogovat citlivé údaje:
  - hesla, čísla dokladů, rodná čísla, mzdy, tokeny, connection stringy.
- Nepřidávat citlivá data do:
  - logů,
  - výjimek,
  - frontendu nebo URL parametrů.
- Konfigurační hodnoty:
  - patří do `appsettings*.json` / `.env` / secrets, ne do kódu jako literály.

---

### 5. Pravidla pro databázi a migrace

- Používat **EF Core migrace** (nebo jiný existující systém) – žádný „ruční“ SQL bez důvodu.
- AI nesmí:
  - mazat tabulky nebo sloupce bez jasného migračního plánu,
  - dělat destruktivní změny schématu bez explicitního požadavku.
- Pokud je změna nevratná, AI má napsat **varování v komentáři PR**, ne ji provést automaticky.

---

### 6. Testování

- Nová logika má mít **unit testy** v existujícím testovacím frameworku (např. xUnit / NUnit / Jest).
- Při opravě bugů:
  - nejdřív přidat (nebo upravit) test, který chybu reprodukuje,
  - pak teprve opravit implementaci.
- AI nesmí mazat testy, které padají, jen proto, aby build „prošel“.

---

### 7. Pravidla pro AI asistenty

- **Co smí:**
  - navrhovat refaktoringy, optimalizace a nové funkce,
  - upravovat existující kód v rámci výše uvedených pravidel,
  - doplňovat dokumentaci a smysluplné komentáře.
- **Co nesmí:**
  - měnit CI/CD konfiguraci bez explicitního požadavku,
  - přidávat nové externí dependency bez důvodu a bez vysvětlení,
  - upravovat licenční soubory, copyright apod.
- Při nejasnostech:
  - preferovat **nejméně invazivní změnu**,
  - raději přidat TODO / poznámku, než spustit rizikovou úpravu.

---

### 8. Komunikace v PR / commitech

- Zprávy commitů:
  - používat stručný formát: `feat: ...`, `fix: ...`, `refactor: ...`, `test: ...`
  - zaměřit se na „proč“, ne jen „co“.
- V popisu PR:
  - krátké shrnutí změn,
  - jak bylo testováno,
  - případná rizika / migrační kroky.

---

### 9. Příklady

- **Správně**:
  - Přidání nové služby do `Application`, interface do `Domain`, implementace do `Infrastructure`.
  - Úprava kontroleru tak, aby volal službu místo přímého přístupu do DB.
- **Špatně**:
  - Nový `DbContext` jen kvůli jedné entitě,
  - Silná logika přímo ve `Controller` třídě,
  - Přidání nové JS knihovny kvůli jedné triviální funkci.