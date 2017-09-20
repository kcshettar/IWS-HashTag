// API courtesy of  https://randomapi.com/
//
// Documentation: https://randomapi.com/documentation

var skills   = ['HTML', 'PHP', 'C', 'C#', 'CSS', 'VB', 'C++', 'Javascript', 'Java', 'Algorithms','Analytics','Android',
'Applications','Blogging','Business','Business Analysis','Business Intelligence','Business Storytelling','Coaching',
'Cloud Computing','Communication','Computer','Consulting','Content','Content Management','Content Marketing','Content Strategy',
'Data Analysis','Data Analytics','Data Engineering','Data Mining','Data Science','Data Warehousing','Database Administration',
'Database Management','Digital Marketing','Digital Media','Economics','Editing','Executive','Event Planning','Game Development',
'Hadoop','Health Care','Hiring','Hospitality','Human Resources','Information Management','Information Security','Information Technology',
'iPhone','Java','Job Specific Skills','Legal','Leadership ','Mac','Management','Marketing','Market Research','Media Planning',
'Microsoft Office Skills','Mobile Apps','Mobile Development','Negotiation','Network and Information Security','Newsletters','Online Marketing',
'Presentation','Project Management','Public Relations','Recruiting','Relationship Management','Research','Risk Management',
'Search Engine Optimization (SEO)','Social Media','Social Media Management','Social Networking','Software','Software Engineering',
'Software Management','Strategic Planning','Strategy','Tech Skills Listed by Job','Tech Support','Technical','Training','UI / UX',
'User Testing','Web Content','Web Development','Web Programming','WordPress','Writing','Windows','UNIX','Linux','IOS']

var randskills = random.numeric(2, 10);
var companyname = getVar('company');
var zip = getVar('zip');

var faker = require('faker'); // Faker.js library

api.postid   = random.special(4, 8);

if (companyname !== null)
{
    api.company  = companyname;
}
else
{
api.company  = faker.company.companyName() || faker.company.companyName() + " " + faker.company.companySuffix();
}

api.address  = faker.address.streetAddress();
api.city     = faker.address.city();
api.state    = faker.address.state();

if (zip !== null)
{
    api.zip  = zip;
}
else
{
    api.zip      = faker.address.zipCode("#####");
}

api.contact  = faker.name.firstName() + " " + faker.name.lastName();
api.email    = api.contact.replace(" ",".") + "@" + 'jobmatch.net'
api.url      = faker.internet.url();
api.phone    = faker.phone.phoneNumber("(800) ###-####") || faker.phone.phoneNumber("(855) ###-####")
api.title    = list(['Software Engineer', 'Linux Administrator', 'Back End Developer', 'Front End Developer', 'QA Software Engineer', 'Manager', 'Senior Software Engineer', 'UI Developer', 'Designer', 'Technical Marketing','DB Engineer']);
api.skills = [];

// Get Skills
var total = 0;
for (var i = 0; i < randskills; i++) {
    var item = list(skills);
    api.skills.push(item);
}
