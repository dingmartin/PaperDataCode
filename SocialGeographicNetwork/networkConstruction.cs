//the script provides the main steps of creating a socio-geographic network, here is an example for a location-location network.  
List<List<int>> locUserlist = new List<List<int>>(); // List<List<int>> save the list of users at each location
List<int> userList = new List<int>();
int n = 10000; //indicate number of locations
for (int i = 0; i < n; i++) 
{
    userList = new List<int>();
    locUserlist.Add(userList); // assign empty userlist to each location
}
string SaveAddress = @"File directory\networkFilename.txt"; //specify a location to save the constructed network
System.IO.FileStream fs = new System.IO.FileStream(SaveAddress, FileMode.Append);

StreamWriter sw = new StreamWriter(fs, Encoding.Default);

string OpenAddress = @"File directory\check-in locations.txt";//one can use the provided check-in location data for network creation
StreamReader sr = new StreamReader(OpenAddress);

while (sr.Peek() > 0)
{

    string rline = sr.ReadLine();
    if (rline.Contains("X"))
        continue;
    string[] rlinesplit = rline.Split('\t');
    int nid = int.Parse(rlinesplit[0]); // read user id
    int locid = int.Parse(rlinesplit[4]); // read location id
    locUserlist[locid].Add(nid); // add user id into the list for the corresponding location
}
for (int i = 0; i < locUserlist.Count; i++)
    locUserlist[i] = locUserlist[i].Distinct().ToList();//remove duplicates of each userlist


OpenAddress = @"File directory\social connections.txt"; //read the edges of the original social network
sr = new StreamReader(OpenAddress);
_matrix = new AdjecencyMatrix<int>(); //here we use matrix to save the connection between any two users.
                                                    // If they have relationship, _matrix[user1,user2]=1, otherwise it equals to 0.
while (sr.Peek() > 0)
{
    string rline = sr.ReadLine();

    string[] rlinesplit = rline.Split('\t');
    int user1 = int.Parse(rlinesplit[0]); //
    int user2 = int.Parse(rlinesplit[1]);
    _matrix[user1, user2] = 1;
    _matrix[user2, user1] = 1; //the network is binary.

}

edge eg = new edge(); //the struct saves the edges of socio-geographic network to be constructed,
                                    //it contains nodeFrom ID, nodeTo ID and weight.
List<edge> eglist = new List<edge>(); 
for (int i = 0; i < n; i++)
{
    for (int j = i + 1; j < n; j++)
    {
        int weight = 0;
        foreach (int p in locUserlist[i])
        {
            foreach (int q in locUserlist[j])
            {
                    if (_matrix[p, q] == 1 || _matrix[q, p] == 1)
                        weight++; //calculate edge weight                 
            }

        }

        if (weight != 0)
        {
            eg.From = i;
            eg.to = j;
            eg.weight = weight;
            eglist.Add(eg);             
        }

    }

}

foreach (edge eg1 in eglist) //write the constructed network into the specified file
{
              
    string text = eg1.From + "\t" + eg1.to + "\t" + eg1.weight;
    sw.WriteLine(text);

}

sw.Close();
fs.Close();
MessageBox.Show("network constructed!");