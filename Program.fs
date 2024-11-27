// Define Records for NBA Team Statistics
type Coach = { 
    Name: string 
    FormerPlayer: bool 
}

type Stats = { 
    Wins: int 
    Losses: int 
}

type Team = { 
    Name: string 
    Coach: Coach 
    Stats: Stats 
}

// Create Coaches
let coach1 = { Name = "Phil Jackson"; FormerPlayer = true }
let coach2 = { Name = "Gregg Popovich"; FormerPlayer = false }
let coach3 = { Name = "Steve Kerr"; FormerPlayer = true }
let coach4 = { Name = "Pat Riley"; FormerPlayer = true }
let coach5 = { Name = "Erik Spoelstra"; FormerPlayer = false }

// Create Stats for Teams
let stats1 = { Wins = 57; Losses = 25 }  // Chicago Bulls
let stats2 = { Wins = 45; Losses = 37 }  // San Antonio Spurs
let stats3 = { Wins = 67; Losses = 15 }  // Golden State Warriors
let stats4 = { Wins = 42; Losses = 40 }  // Los Angeles Lakers
let stats5 = { Wins = 40; Losses = 42 }  // Miami Heat

// Create Teams
let team1 = { Name = "Chicago Bulls"; Coach = coach1; Stats = stats1 }
let team2 = { Name = "San Antonio Spurs"; Coach = coach2; Stats = stats2 }
let team3 = { Name = "Golden State Warriors"; Coach = coach3; Stats = stats3 }
let team4 = { Name = "Los Angeles Lakers"; Coach = coach4; Stats = stats4 }
let team5 = { Name = "Miami Heat"; Coach = coach5; Stats = stats5 }

// Create a List of Teams
let teams = [team1; team2; team3; team4; team5]

// Filter Successful Teams
let successfulTeams = 
    teams 
    |> List.filter (fun team -> team.Stats.Wins > team.Stats.Losses)

// Map Success Percentages
let successPercentages = 
    teams 
    |> List.map (fun team -> 
        let winRate = float team.Stats.Wins / float (team.Stats.Wins + team.Stats.Losses) * 100.0
        team.Name, winRate
    )

// Print Results
[<EntryPoint>]
let main argv = 
    // Print All Teams
    printfn "All NBA Teams and Coaches:"
    teams |> List.iter (fun team -> 
        printfn "%s (Coach: %s, Former Player: %b, Wins: %d, Losses: %d)" 
            team.Name 
            team.Coach.Name 
            team.Coach.FormerPlayer
            team.Stats.Wins 
            team.Stats.Losses)

    // Print Successful Teams
    printfn "\nSuccessful Teams (More Wins than Losses):"
    successfulTeams |> List.iter (fun team -> 
        printfn "%s (Coach: %s)" team.Name team.Coach.Name)

    // Print Success Percentages
    printfn "\nTeam Success Percentages:"
    successPercentages |> List.iter (fun (name, percentage) -> 
        printfn "%s: %.2f%%" name percentage)

    0 // Return code
