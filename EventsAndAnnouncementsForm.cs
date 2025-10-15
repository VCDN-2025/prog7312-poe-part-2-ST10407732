using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using MunicipalServicesApp.Models;
using MunicipalServicesApp.DataStructures;

namespace MunicipalServicesApp
{
    public partial class EventsAndAnnouncementsForm : Form
    {
        // Data structures
        private CustomSortedDictionary<string, Event> eventsByDate;
        private CustomDictionary<string, Event> eventsById;
        private CustomSet<string> categories;
        private CustomSet<string> uniqueDates;
        private CustomQueue<Event> recentlyViewedEvents;
        private CustomPriorityQueue<Event> upcomingEvents;

        private RecommendationEngine recommendationEngine;

        // UI Components
        private Panel mainPanel;
        private Panel searchPanel;
        private TextBox txtSearch;
        private ComboBox cmbCategory;
        private DateTimePicker dtpDate;
        private Button btnSearch;
        private Button btnClearFilters;
        private Button btnShowRecommendations;
        private Button btnBack;
        private FlowLayoutPanel eventsContainer;
        private ComboBox cmbSort;
        private Label lblResultCount;

        // Enhanced Colors
        private static readonly Color PrimaryTeal = Color.FromArgb(0, 123, 139);
        private static readonly Color SecondaryTeal = Color.FromArgb(0, 150, 167);
        private static readonly Color AccentBlue = Color.FromArgb(21, 101, 192);
        private static readonly Color SuccessGreen = Color.FromArgb(76, 175, 80);
        private static readonly Color WarningOrange = Color.FromArgb(255, 152, 0);
        private static readonly Color LightGray = Color.FromArgb(248, 249, 250);
        private static readonly Color DarkGray = Color.FromArgb(66, 66, 66);
        private static readonly Color BorderGray = Color.FromArgb(224, 224, 224);
        private static readonly Color CardShadow = Color.FromArgb(30, 0, 0, 0);

        public EventsAndAnnouncementsForm()
        {
            InitializeComponent();
            InitializeDataStructures();
            LoadSampleData();
            BuildUI();
        }

        private void InitializeDataStructures()
        {
            eventsByDate = new CustomSortedDictionary<string, Event>();
            eventsById = new CustomDictionary<string, Event>();
            categories = new CustomSet<string>();
            uniqueDates = new CustomSet<string>();
            recentlyViewedEvents = new CustomQueue<Event>();
            upcomingEvents = new CustomPriorityQueue<Event>();
            recommendationEngine = new RecommendationEngine();
        }

        private void LoadSampleData()
        {
            var events = new[]
            {
                new Event("E001", "Community Clean-Up Day", "Community", new DateTime(2025, 10, 20), "City Park", "Join us for a day of community service", "", 1),
                new Event("E002", "Municipal Budget Meeting", "Government", new DateTime(2025, 10, 25), "City Hall", "Annual budget review and public input session", "", 2),
                new Event("E003", "Road Maintenance Notice", "Infrastructure", new DateTime(2025, 10, 18), "Main Street", "Scheduled road repairs from 8am-4pm", "", 1),
                new Event("E004", "Free Health Screening", "Health", new DateTime(2025, 10, 22), "Community Center", "Free health checks for all residents", "", 1),
                new Event("E005", "Youth Sports Tournament", "Sports", new DateTime(2025, 11, 5), "Sports Complex", "Annual youth soccer tournament", "", 2),
                new Event("E006", "Arts & Culture Festival", "Culture", new DateTime(2025, 11, 12), "Town Square", "Celebrate local artists and performers", "", 3),
                new Event("E007", "Water Supply Maintenance", "Infrastructure", new DateTime(2025, 10, 19), "Zone 3 Areas", "Temporary water interruption 6am-12pm", "", 1),
                new Event("E008", "Job Fair", "Employment", new DateTime(2025, 10, 28), "Convention Center", "Meet local employers and explore opportunities", "", 2),
                new Event("E009", "Senior Citizens Lunch", "Community", new DateTime(2025, 10, 30), "Senior Center", "Monthly social gathering for seniors", "", 2),
                new Event("E010", "Recycling Awareness Day", "Environment", new DateTime(2025, 11, 8), "City Park", "Learn about recycling and sustainability", "", 2),
                new Event("E011", "Municipal Election Info Session", "Government", new DateTime(2025, 11, 15), "City Hall", "Learn about upcoming local elections", "", 3),
                new Event("E012", "Street Market", "Community", new DateTime(2025, 10, 26), "Market Square", "Weekly farmers and craft market", "", 1),
                new Event("E013", "Public Safety Workshop", "Safety", new DateTime(2025, 11, 3), "Police Station", "Community safety and crime prevention tips", "", 2),
                new Event("E014", "Library Book Sale", "Culture", new DateTime(2025, 11, 10), "Public Library", "Annual book sale - all proceeds to library", "", 2),
                new Event("E015", "Traffic Light Installation", "Infrastructure", new DateTime(2025, 10, 24), "Oak Street", "New traffic signals being installed", "", 1),
                new Event("E016", "Small Business Workshop", "Employment", new DateTime(2025, 11, 18), "Business Center", "Starting your own business seminar", "", 3),
                new Event("E017", "Park Renovation Update", "Infrastructure", new DateTime(2025, 11, 1), "Riverside Park", "Construction progress and timeline", "", 2),
                new Event("E018", "Food Drive", "Community", new DateTime(2025, 10, 21), "Various Locations", "Donate non-perishable foods for families in need", "", 1),
                new Event("E019", "Fire Safety Demonstration", "Safety", new DateTime(2025, 11, 7), "Fire Station", "Learn fire safety and prevention", "", 2),
                new Event("E020", "Music in the Park", "Culture", new DateTime(2025, 11, 14), "Central Park", "Live music performances every Sunday", "", 3),
                new Event("E021", "Vaccination Drive", "Health", new DateTime(2025, 10, 27), "Health Clinic", "Free flu shots for all ages", "", 2),
                new Event("E022", "Youth Coding Workshop", "Education", new DateTime(2025, 11, 9), "Tech Hub", "Learn programming basics for ages 12-18", "", 2),
                new Event("E023", "Neighborhood Watch Meeting", "Safety", new DateTime(2025, 10, 23), "Community Hall", "Monthly safety update and planning session", "", 1),
                new Event("E024", "Marathon Registration", "Sports", new DateTime(2025, 11, 20), "Sports Arena", "Register for the annual city marathon", "", 3),
                new Event("E025", "Tax Workshop for Seniors", "Government", new DateTime(2025, 11, 6), "Senior Center", "Free tax assistance and advice", "", 2),
                new Event("E026", "Environmental Film Screening", "Environment", new DateTime(2025, 11, 13), "Town Cinema", "Documentary about climate change", "", 2),
                new Event("E027", "Career Mentorship Program", "Employment", new DateTime(2025, 10, 29), "Business Center", "Connect with industry professionals", "", 2),
                new Event("E028", "Bridge Maintenance Alert", "Infrastructure", new DateTime(2025, 10, 31), "River Bridge", "Bridge repairs - expect delays", "", 1),
                new Event("E029", "Halloween Community Party", "Community", new DateTime(2025, 10, 31), "Town Square", "Family-friendly Halloween celebration", "", 1),
                new Event("E030", "Poetry Reading Night", "Culture", new DateTime(2025, 11, 16), "Public Library", "Local poets share their work", "", 3),
                new Event("E031", "Mental Health Awareness", "Health", new DateTime(2025, 11, 11), "Wellness Center", "Free counseling sessions and resources", "", 2),
                new Event("E032", "Basketball Tournament", "Sports", new DateTime(2025, 11, 19), "Sports Complex", "Youth basketball championship finals", "", 3),
                new Event("E033", "Town Hall Q&A Session", "Government", new DateTime(2025, 11, 22), "City Hall", "Ask the mayor anything", "", 3),
                new Event("E034", "Tree Planting Initiative", "Environment", new DateTime(2025, 11, 2), "Memorial Park", "Help plant 100 trees in the community", "", 1),
                new Event("E035", "Resume Writing Workshop", "Employment", new DateTime(2025, 11, 4), "Career Center", "Professional resume tips and review", "", 2),
                new Event("E036", "Street Light Upgrades", "Infrastructure", new DateTime(2025, 11, 10), "Downtown Area", "LED street light installation project", "", 1),
                new Event("E037", "Bingo Night Fundraiser", "Community", new DateTime(2025, 11, 17), "Recreation Center", "Fundraiser for local schools", "", 2),
                new Event("E038", "Photography Exhibition", "Culture", new DateTime(2025, 11, 21), "Art Gallery", "Local photographers showcase their work", "", 3),
                new Event("E039", "First Aid Training", "Safety", new DateTime(2025, 11, 23), "Fire Station", "Learn basic first aid and CPR", "", 2),
                new Event("E040", "Blood Donation Drive", "Health", new DateTime(2025, 11, 24), "Hospital", "Donate blood and save lives", "", 2),
                new Event("E041", "Chess Tournament", "Sports", new DateTime(2025, 11, 25), "Community Center", "All ages chess competition", "", 2),
                new Event("E042", "Holiday Market Opening", "Community", new DateTime(2025, 11, 28), "Market Square", "Start your holiday shopping early", "", 3),
                new Event("E043", "Wildlife Conservation Talk", "Environment", new DateTime(2025, 11, 27), "Nature Center", "Learn about local wildlife protection", "", 2),
                new Event("E044", "Freelancing Workshop", "Employment", new DateTime(2025, 11, 30), "Co-working Space", "How to start freelancing successfully", "", 3),
                new Event("E045", "Sidewalk Repairs Notice", "Infrastructure", new DateTime(2025, 11, 26), "Elm Street", "Sidewalk construction for two weeks", "", 1)
            };

            foreach (var evt in events)
            {
                string dateKey = evt.Date.ToString("yyyy-MM-dd");
                eventsByDate.Add(dateKey, evt);
                eventsById.Add(evt.EventId, evt);
                categories.Add(evt.Category);
                uniqueDates.Add(dateKey);

                if (evt.Date >= DateTime.Now)
                {
                    upcomingEvents.Enqueue(evt);
                }
            }
        }

        private void BuildUI()
        {
            this.Text = "📢 Local Events & Announcements";
            this.Size = new Size(1400, 850);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = LightGray;

            TableLayoutPanel mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 4,
                ColumnCount = 1,
                Padding = new Padding(0)
            };
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

            // Header with Back Button
            Panel header = CreateHeader();
            mainLayout.Controls.Add(header, 0, 0);

            // Search Panel
            searchPanel = CreateSearchPanel();
            mainLayout.Controls.Add(searchPanel, 0, 1);

            // Content Area
            mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = LightGray,
                Padding = new Padding(0, 10, 0, 10)
            };

            eventsContainer = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                Padding = new Padding(25, 10, 25, 10)
            };
            mainPanel.Controls.Add(eventsContainer);

            mainLayout.Controls.Add(mainPanel, 0, 2);

            // Footer
            Panel footer = CreateFooter();
            mainLayout.Controls.Add(footer, 0, 3);

            this.Controls.Add(mainLayout);

            DisplayEvents(eventsById.GetAllValues());
        }

        private Panel CreateHeader()
        {
            Panel header = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0) };
            header.Paint += (s, pe) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    header.ClientRectangle, PrimaryTeal, SecondaryTeal, LinearGradientMode.Horizontal))
                {
                    pe.Graphics.FillRectangle(brush, header.ClientRectangle);
                }
            };

            // Back Button
            btnBack = new Button
            {
                Text = "⬅ Back to Menu",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(200, 255, 255, 255),
                ForeColor = PrimaryTeal,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(150, 35),
                Location = new Point(20, 15),
                Cursor = Cursors.Hand
            };
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Click += (s, e) => this.Close();

            Color btnHoverColor = Color.White;
            btnBack.MouseEnter += (s, e) => btnBack.BackColor = btnHoverColor;
            btnBack.MouseLeave += (s, e) => btnBack.BackColor = Color.FromArgb(200, 255, 255, 255);

            Label lblTitle = new Label
            {
                Text = "📢 LOCAL EVENTS & ANNOUNCEMENTS",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                AutoSize = false,
                Size = new Size(1400, 60),
                Location = new Point(0, 10),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblSubtitle = new Label
            {
                Text = "Discover what's happening in your community",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.FromArgb(230, 255, 255),
                BackColor = Color.Transparent,
                AutoSize = false,
                Size = new Size(1400, 30),
                Location = new Point(0, 70),
                TextAlign = ContentAlignment.TopCenter
            };

            header.Controls.Add(btnBack);
            header.Controls.Add(lblTitle);
            header.Controls.Add(lblSubtitle);

            return header;
        }

        private Panel CreateSearchPanel()
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(25, 15, 25, 15)
            };

            panel.Paint += (s, pe) =>
            {
                Rectangle shadowRect = new Rectangle(0, panel.Height - 3, panel.Width, 3);
                using (LinearGradientBrush shadowBrush = new LinearGradientBrush(
                    shadowRect, Color.FromArgb(20, 0, 0, 0), Color.Transparent, 90f))
                {
                    pe.Graphics.FillRectangle(shadowBrush, shadowRect);
                }
            };

            Label lblSearchTitle = new Label
            {
                Text = "🔍 Search & Filter Events",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = DarkGray,
                Location = new Point(25, 15),
                AutoSize = true
            };

            txtSearch = CreateStyledTextBox("Search by title or description...", new Point(25, 45), 280);
            cmbCategory = CreateStyledComboBox(new Point(320, 45), 200);
            cmbCategory.Items.Add("All Categories");
            foreach (var cat in categories.ToList().OrderBy(c => c))
            {
                cmbCategory.Items.Add(cat);
            }
            cmbCategory.SelectedIndex = 0;

            dtpDate = new DateTimePicker
            {
                Font = new Font("Segoe UI", 11),
                Width = 200,
                Location = new Point(535, 45),
                Format = DateTimePickerFormat.Short
            };

            cmbSort = CreateStyledComboBox(new Point(750, 45), 180);
            cmbSort.Items.AddRange(new string[] { "Sort by Date", "Sort by Category", "Sort by Title" });
            cmbSort.SelectedIndex = 0;

            btnSearch = CreateActionButton("🔍 Search", AccentBlue, new Point(25, 85), 140);
            btnSearch.Click += BtnSearch_Click;

            btnClearFilters = CreateActionButton("🔄 Clear", WarningOrange, new Point(175, 85), 130);
            btnClearFilters.Click += BtnClearFilters_Click;

            btnShowRecommendations = CreateActionButton("⭐ Recommendations", SuccessGreen, new Point(315, 85), 200);
            btnShowRecommendations.Click += BtnShowRecommendations_Click;

            lblResultCount = new Label
            {
                Text = $"Showing {eventsById.GetAllValues().Count} events",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.Gray,
                Location = new Point(950, 92),
                AutoSize = true
            };

            panel.Controls.AddRange(new Control[] {
                lblSearchTitle, txtSearch, cmbCategory, dtpDate, cmbSort,
                btnSearch, btnClearFilters, btnShowRecommendations, lblResultCount
            });

            return panel;
        }

        private TextBox CreateStyledTextBox(string placeholder, Point location, int width)
        {
            TextBox txt = new TextBox
            {
                Font = new Font("Segoe UI", 11),
                Width = width,
                Location = location,
                Text = placeholder,
                ForeColor = Color.Gray
            };
            txt.GotFocus += (s, e) => {
                if (txt.Text == placeholder)
                {
                    txt.Text = "";
                    txt.ForeColor = DarkGray;
                }
            };
            txt.LostFocus += (s, e) => {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                }
            };
            return txt;
        }

        private ComboBox CreateStyledComboBox(Point location, int width)
        {
            return new ComboBox
            {
                Font = new Font("Segoe UI", 11),
                Width = width,
                Location = location,
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat
            };
        }

        private Button CreateActionButton(string text, Color color, Point location, int width)
        {
            Button btn = new Button
            {
                Text = text,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = color,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = width,
                Height = 40,
                Location = location,
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;

            Color hoverColor = ControlPaint.Light(color, 0.2f);
            btn.MouseEnter += (s, e) => btn.BackColor = hoverColor;
            btn.MouseLeave += (s, e) => btn.BackColor = color;

            return btn;
        }

        private Panel CreateFooter()
        {
            Panel footer = new Panel { Dock = DockStyle.Fill };
            footer.Paint += (s, pe) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    footer.ClientRectangle, PrimaryTeal, SecondaryTeal, LinearGradientMode.Horizontal))
                {
                    pe.Graphics.FillRectangle(brush, footer.ClientRectangle);
                }
            };

            Label lblFooter = new Label
            {
                Text = "📞 0800-123-456  |  ✉️ events@municipality.gov.za  |  © 2025 Municipal Services",
                ForeColor = Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10, FontStyle.Regular)
            };
            footer.Controls.Add(lblFooter);

            return footer;
        }

        private void DisplayEvents(System.Collections.Generic.List<Event> events)
        {
            eventsContainer.Controls.Clear();

            if (events == null || events.Count == 0)
            {
                Panel noEventsPanel = new Panel
                {
                    Width = 400,
                    Height = 200,
                    BackColor = Color.White
                };
                noEventsPanel.Paint += (s, pe) =>
                {
                    pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    var path = GetRoundedRectanglePath(new Rectangle(0, 0, noEventsPanel.Width, noEventsPanel.Height), 12);
                    using (var brush = new SolidBrush(Color.White))
                        pe.Graphics.FillPath(brush, path);
                };

                Label noEvents = new Label
                {
                    Text = "❌ No Events Found\n\nTry adjusting your search filters",
                    Font = new Font("Segoe UI", 12),
                    ForeColor = Color.Gray,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };
                noEventsPanel.Controls.Add(noEvents);
                eventsContainer.Controls.Add(noEventsPanel);

                if (lblResultCount != null)
                    lblResultCount.Text = "No events found";
                return;
            }

            var sortedEvents = events;
            if (cmbSort != null && cmbSort.SelectedIndex >= 0)
            {
                switch (cmbSort.SelectedIndex)
                {
                    case 0: sortedEvents = events.OrderBy(e => e.Date).ToList(); break;
                    case 1: sortedEvents = events.OrderBy(e => e.Category).ThenBy(e => e.Date).ToList(); break;
                    case 2: sortedEvents = events.OrderBy(e => e.Title).ToList(); break;
                }
            }

            foreach (var evt in sortedEvents)
            {
                eventsContainer.Controls.Add(CreateEventCard(evt));
            }

            if (lblResultCount != null)
                lblResultCount.Text = $"Showing {events.Count} event{(events.Count != 1 ? "s" : "")}";
        }

        private Panel CreateEventCard(Event evt)
        {
            Panel card = new Panel
            {
                Width = 380,
                Height = 240,
                Margin = new Padding(12),
                Cursor = Cursors.Hand,
                Tag = evt,
                BackColor = Color.White
            };

            card.Paint += (s, pe) =>
            {
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                var shadowRect = new Rectangle(4, 4, card.Width - 4, card.Height - 4);
                var shadowPath = GetRoundedRectanglePath(shadowRect, 12);
                using (var shadowBrush = new SolidBrush(CardShadow))
                    pe.Graphics.FillPath(shadowBrush, shadowPath);

                var rect = new Rectangle(0, 0, card.Width - 6, card.Height - 6);
                var path = GetRoundedRectanglePath(rect, 12);
                using (var brush = new SolidBrush(Color.White))
                    pe.Graphics.FillPath(brush, path);
                using (var borderPen = new Pen(BorderGray, 1))
                    pe.Graphics.DrawPath(borderPen, path);

                Color categoryColor = GetCategoryColor(evt.Category);
                using (var accentBrush = new SolidBrush(categoryColor))
                {
                    var accentPath = new GraphicsPath();
                    accentPath.AddArc(0, 0, 24, 24, 180, 90);
                    accentPath.AddLine(12, 0, card.Width - 18, 0);
                    accentPath.AddArc(card.Width - 30, 0, 24, 24, 270, 90);
                    accentPath.AddLine(card.Width - 6, 12, 0, 12);
                    accentPath.CloseFigure();
                    pe.Graphics.FillPath(accentBrush, accentPath);
                }
            };

            Panel dateBadge = new Panel
            {
                Size = new Size(75, 75),
                Location = new Point(18, 28),
                BackColor = Color.Transparent
            };
            dateBadge.Paint += (s, pe) =>
            {
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var brush = new SolidBrush(AccentBlue))
                    pe.Graphics.FillEllipse(brush, 0, 0, 75, 75);
                using (var borderPen = new Pen(Color.White, 4))
                    pe.Graphics.DrawEllipse(borderPen, 2, 2, 71, 71);
            };

            Label lblDay = new Label
            {
                Text = evt.Date.Day.ToString(),
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent,
                Location = new Point(0, 14),
                Size = new Size(75, 35)
            };
            Label lblMonth = new Label
            {
                Text = evt.Date.ToString("MMM").ToUpper(),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.TopCenter,
                BackColor = Color.Transparent,
                Location = new Point(0, 48),
                Size = new Size(75, 22)
            };
            dateBadge.Controls.Add(lblDay);
            dateBadge.Controls.Add(lblMonth);

            Label lblTitle = new Label
            {
                Text = evt.Title,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 33, 33),
                BackColor = Color.Transparent,
                Location = new Point(105, 28),
                Size = new Size(260, 60),
                AutoEllipsis = true
            };

            Panel categoryBadge = new Panel
            {
                Location = new Point(105, 88),
                Size = new Size(260, 26),
                BackColor = Color.Transparent
            };

            Label lblCategory = new Label
            {
                Text = $"📁 {evt.Category}",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = GetCategoryColor(evt.Category),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(8, 4, 8, 4),
                AutoSize = true,
                Location = new Point(0, 0)
            };
            categoryBadge.Controls.Add(lblCategory);

            Label lblLocation = new Label
            {
                Text = $"📍 {evt.Location}",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.FromArgb(90, 90, 90),
                BackColor = Color.Transparent,
                Location = new Point(18, 120),
                Size = new Size(350, 24),
                AutoEllipsis = true
            };

            Label lblDescription = new Label
            {
                Text = evt.Description,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(110, 110, 110),
                BackColor = Color.Transparent,
                Location = new Point(18, 148),
                Size = new Size(350, 50),
                AutoEllipsis = true
            };

            Panel actionPanel = new Panel
            {
                Location = new Point(0, 203),
                Size = new Size(card.Width - 6, 37),
                BackColor = Color.FromArgb(240, 245, 250)
            };
            actionPanel.Paint += (s, pe) =>
            {
                pe.Graphics.DrawLine(new Pen(Color.FromArgb(200, 200, 200), 2), 0, 0, actionPanel.Width, 0);
            };

            Label lblViewDetails = new Label
            {
                Text = "View Full Details →",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = AccentBlue,
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };
            actionPanel.Controls.Add(lblViewDetails);

            card.Controls.AddRange(new Control[] {
                actionPanel, dateBadge, lblTitle, categoryBadge, lblLocation, lblDescription
            });

            card.Click += (s, e) => ShowEventDetails(evt);
            foreach (Control ctrl in card.Controls)
            {
                ctrl.Click += (s, e) => ShowEventDetails(evt);
                foreach (Control subCtrl in ctrl.Controls)
                {
                    subCtrl.Click += (s, e) => ShowEventDetails(evt);
                }
            }

            return card;
        }

        private Color GetCategoryColor(string category)
        {
            switch (category)
            {
                case "Community": return SuccessGreen;
                case "Government": return AccentBlue;
                case "Infrastructure": return WarningOrange;
                case "Health": return Color.FromArgb(233, 30, 99);
                case "Sports": return Color.FromArgb(156, 39, 176);
                case "Culture": return Color.FromArgb(255, 87, 34);
                case "Environment": return Color.FromArgb(76, 175, 80);
                case "Employment": return Color.FromArgb(63, 81, 181);
                case "Safety": return Color.FromArgb(244, 67, 54);
                case "Education": return Color.FromArgb(3, 169, 244);
                default: return DarkGray;
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text == "Search by title or description..." ? "" : txtSearch.Text;
            string selectedCategory = cmbCategory.SelectedItem?.ToString();
            DateTime selectedDate = dtpDate.Value.Date;

            var filteredEvents = eventsById.GetAllValues();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                filteredEvents = filteredEvents
                    .Where(ev => ev.Title.ToLower().Contains(searchText.ToLower()) ||
                                 ev.Description.ToLower().Contains(searchText.ToLower()))
                    .ToList();
            }

            if (selectedCategory != "All Categories" && !string.IsNullOrEmpty(selectedCategory))
            {
                filteredEvents = filteredEvents.Where(ev => ev.Category == selectedCategory).ToList();
                recommendationEngine.TrackCategorySearch(selectedCategory);
            }

            bool filterByDate = MessageBox.Show("Filter by selected date?", "Date Filter",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

            if (filterByDate)
            {
                filteredEvents = filteredEvents.Where(ev => ev.Date.Date == selectedDate).ToList();
                recommendationEngine.TrackDateSearch(selectedDate);
            }

            DisplayEvents(filteredEvents);
        }

        private void BtnClearFilters_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "Search by title or description...";
            txtSearch.ForeColor = Color.Gray;
            cmbCategory.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            dtpDate.Value = DateTime.Now;
            DisplayEvents(eventsById.GetAllValues());
        }

        private void BtnShowRecommendations_Click(object sender, EventArgs e)
        {
            var allEvents = eventsById.GetAllValues();
            var recommendations = recommendationEngine.GetRecommendedEvents(allEvents, 6);
            bool hasSearchHistory = recommendationEngine.GetTotalSearchCount() > 0;

            Form recForm = new Form
            {
                Text = "⭐ Event Recommendations",
                Size = new Size(1400, 950),
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = LightGray,
                WindowState = FormWindowState.Normal,
                MaximizeBox = true
            };

            // Main scrollable container
            Panel scrollContainer = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = LightGray
            };

            // Inner content panel with fixed width
            Panel contentPanel = new Panel
            {
                Width = 1360,
                AutoSize = true,
                Location = new Point(10, 10),
                BackColor = LightGray
            };

            int yPos = 10;

            // Back button at top
            Button btnBackRec = new Button
            {
                Text = "⬅ Back",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = DarkGray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(120, 40),
                Location = new Point(20, yPos),
                Cursor = Cursors.Hand
            };
            btnBackRec.FlatAppearance.BorderSize = 0;
            btnBackRec.Click += (s, ev) => recForm.Close();
            contentPanel.Controls.Add(btnBackRec);
            yPos += 60;

            // Personalized section
            if (hasSearchHistory)
            {
                var personalizedEvents = recommendations.Take(6).ToList();

                Panel personalizedHeader = new Panel
                {
                    Location = new Point(0, yPos),
                    Size = new Size(1340, 100),
                    BackColor = SuccessGreen
                };
                personalizedHeader.Paint += (s, pe) =>
                {
                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        personalizedHeader.ClientRectangle, SuccessGreen, Color.FromArgb(102, 187, 106), LinearGradientMode.Horizontal))
                    {
                        pe.Graphics.FillRectangle(brush, personalizedHeader.ClientRectangle);
                    }
                };

                Label lblPersonalizedTitle = new Label
                {
                    Text = "⭐ FOR YOU - Based on Your Searches",
                    Font = new Font("Segoe UI", 18, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = Color.Transparent,
                    AutoSize = false,
                    Size = new Size(1280, 50),
                    Location = new Point(30, 15),
                    TextAlign = ContentAlignment.MiddleLeft
                };

                Label lblPersonalizedSubtitle = new Label
                {
                    Text = "Events matching your interests and search history",
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Color.FromArgb(230, 255, 230),
                    BackColor = Color.Transparent,
                    AutoSize = false,
                    Size = new Size(1280, 30),
                    Location = new Point(30, 60),
                    TextAlign = ContentAlignment.TopLeft
                };

                personalizedHeader.Controls.Add(lblPersonalizedTitle);
                personalizedHeader.Controls.Add(lblPersonalizedSubtitle);
                contentPanel.Controls.Add(personalizedHeader);
                yPos += 110;

                FlowLayoutPanel personalizedFlow = new FlowLayoutPanel
                {
                    Location = new Point(10, yPos),
                    Size = new Size(1320, 280),
                    FlowDirection = FlowDirection.LeftToRight,
                    WrapContents = true,
                    Padding = new Padding(10),
                    BackColor = LightGray,
                    AutoScroll = false
                };

                foreach (var evt in personalizedEvents)
                {
                    personalizedFlow.Controls.Add(CreateEventCard(evt));
                }

                contentPanel.Controls.Add(personalizedFlow);
                yPos += 290;

                Panel divider = new Panel
                {
                    Location = new Point(40, yPos),
                    Size = new Size(1260, 3),
                    BackColor = BorderGray
                };
                contentPanel.Controls.Add(divider);
                yPos += 25;
            }

            // Trending section
            var trendingEvents = allEvents
                .Where(ev => ev.Date >= DateTime.Now && ev.Priority >= 2)
                .OrderByDescending(ev => ev.Priority)
                .ThenBy(ev => ev.Date)
                .Take(3)
                .ToList();

            Panel trendingHeader = new Panel
            {
                Location = new Point(0, yPos),
                Size = new Size(1340, 90),
                BackColor = AccentBlue
            };
            trendingHeader.Paint += (s, pe) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    trendingHeader.ClientRectangle, AccentBlue, Color.FromArgb(48, 123, 204), LinearGradientMode.Horizontal))
                {
                    pe.Graphics.FillRectangle(brush, trendingHeader.ClientRectangle);
                }
            };

            Label lblTrendingTitle = new Label
            {
                Text = "🔥 TRENDING EVENTS - Popular in Your Area",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                AutoSize = false,
                Size = new Size(1280, 45),
                Location = new Point(30, 15),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblTrendingSubtitle = new Label
            {
                Text = "High-priority upcoming events in the community",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(220, 240, 255),
                BackColor = Color.Transparent,
                AutoSize = false,
                Size = new Size(1280, 25),
                Location = new Point(30, 55),
                TextAlign = ContentAlignment.TopLeft
            };

            trendingHeader.Controls.Add(lblTrendingTitle);
            trendingHeader.Controls.Add(lblTrendingSubtitle);
            contentPanel.Controls.Add(trendingHeader);
            yPos += 100;

            FlowLayoutPanel trendingFlow = new FlowLayoutPanel
            {
                Location = new Point(10, yPos),
                Size = new Size(1320, 280),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new Padding(10),
                BackColor = Color.FromArgb(250, 250, 252)
            };

            foreach (var evt in trendingEvents)
                trendingFlow.Controls.Add(CreateEventCard(evt));

            contentPanel.Controls.Add(trendingFlow);
            yPos += 290;

            // Statistics panel
            Panel statsPanel = new Panel
            {
                Location = new Point(10, yPos),
                Size = new Size(1320, 140),
                BackColor = Color.FromArgb(242, 245, 249),
                Padding = new Padding(25, 10, 25, 10),
                BorderStyle = BorderStyle.None
            };

            Panel line = new Panel
            {
                Dock = DockStyle.Top,
                Height = 2,
                BackColor = Color.FromArgb(210, 210, 210)
            };
            statsPanel.Controls.Add(line);

            Label lblStatsTitle = new Label
            {
                Text = "📈 Search Activity Summary",
                Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 60, 90),
                Location = new Point(30, 20),
                AutoSize = true
            };
            statsPanel.Controls.Add(lblStatsTitle);

            Label lblStats = new Label
            {
                Text = recommendationEngine.GetSearchStatistics(),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(70, 70, 70),
                Location = new Point(30, 55),
                Size = new Size(1250, 70),
                BackColor = Color.Transparent
            };
            statsPanel.Controls.Add(lblStats);

            statsPanel.Paint += (s, ev) =>
            {
                using (Pen p = new Pen(Color.FromArgb(200, 200, 200), 1))
                {
                    ev.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    ev.Graphics.DrawRectangle(p, 0, 0, statsPanel.Width - 1, statsPanel.Height - 1);
                }
            };

            contentPanel.Controls.Add(statsPanel);
            yPos += 160;

            contentPanel.Height = yPos;
            scrollContainer.Controls.Add(contentPanel);
            recForm.Controls.Add(scrollContainer);
            recForm.ShowDialog();
        }

        private void ShowEventDetails(Event evt)
        {
            if (recentlyViewedEvents.Count >= 5)
            {
                recentlyViewedEvents.Dequeue();
            }
            recentlyViewedEvents.Enqueue(evt);

            Form detailForm = new Form
            {
                Text = "Event Details",
                Size = new Size(700, 650),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = LightGray,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                Padding = new Padding(30)
            };
            headerPanel.Paint += (s, pe) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    headerPanel.ClientRectangle,
                    GetCategoryColor(evt.Category),
                    ControlPaint.Light(GetCategoryColor(evt.Category), 0.3f),
                    LinearGradientMode.Horizontal))
                {
                    pe.Graphics.FillRectangle(brush, headerPanel.ClientRectangle);
                }
            };

            Label lblDetailTitle = new Label
            {
                Text = evt.Title,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                AutoSize = false,
                Size = new Size(620, 100),
                Location = new Point(20, 10),
                TextAlign = ContentAlignment.MiddleCenter
            };
            headerPanel.Controls.Add(lblDetailTitle);

            Panel contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(40, 30, 40, 30),
                AutoScroll = true,
                BackColor = Color.White
            };

            int yPos = 20;
            void AddDetailRow(string icon, string label, string value, Color color)
            {
                Panel row = new Panel
                {
                    Location = new Point(10, yPos),
                    Size = new Size(580, 65),
                    BackColor = Color.FromArgb(248, 249, 250)
                };
                row.Paint += (s, pe) =>
                {
                    var path = GetRoundedRectanglePath(new Rectangle(0, 0, row.Width, row.Height), 8);
                    using (var brush = new SolidBrush(Color.FromArgb(248, 249, 250)))
                    {
                        pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        pe.Graphics.FillPath(brush, path);
                    }
                };

                Label lblIcon = new Label
                {
                    Text = icon,
                    Font = new Font("Segoe UI", 18),
                    BackColor = Color.Transparent,
                    Location = new Point(15, 18),
                    Size = new Size(40, 30)
                };

                Label lblLabel = new Label
                {
                    Text = label,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = color,
                    BackColor = Color.Transparent,
                    Location = new Point(65, 12),
                    Size = new Size(500, 20),
                    AutoEllipsis = false
                };

                Label lblValue = new Label
                {
                    Text = value,
                    Font = new Font("Segoe UI", 11),
                    ForeColor = DarkGray,
                    BackColor = Color.Transparent,
                    Location = new Point(65, 32),
                    Size = new Size(500, 25),
                    AutoEllipsis = false
                };

                row.Controls.Add(lblIcon);
                row.Controls.Add(lblLabel);
                row.Controls.Add(lblValue);
                contentPanel.Controls.Add(row);
                yPos += 75;
            }

            AddDetailRow("📁", "CATEGORY", evt.Category, GetCategoryColor(evt.Category));
            AddDetailRow("📅", "DATE & TIME", evt.Date.ToString("dddd, MMMM dd, yyyy"), AccentBlue);
            AddDetailRow("📍", "LOCATION", evt.Location, WarningOrange);

            Panel descPanel = new Panel
            {
                Location = new Point(10, yPos),
                Size = new Size(580, 160),
                BackColor = Color.FromArgb(248, 249, 250)
            };
            descPanel.Paint += (s, pe) =>
            {
                var path = GetRoundedRectanglePath(new Rectangle(0, 0, descPanel.Width, descPanel.Height), 8);
                using (var brush = new SolidBrush(Color.FromArgb(248, 249, 250)))
                {
                    pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    pe.Graphics.FillPath(brush, path);
                }
            };

            Label lblDescTitle = new Label
            {
                Text = "📝 DESCRIPTION",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = SuccessGreen,
                BackColor = Color.Transparent,
                Location = new Point(20, 15),
                AutoSize = true
            };

            Label lblDesc = new Label
            {
                Text = evt.Description,
                Font = new Font("Segoe UI", 11),
                ForeColor = DarkGray,
                BackColor = Color.Transparent,
                Location = new Point(20, 45),
                Size = new Size(540, 100),
                AutoEllipsis = false
            };

            descPanel.Controls.Add(lblDescTitle);
            descPanel.Controls.Add(lblDesc);
            contentPanel.Controls.Add(descPanel);

            Button btnClose = new Button
            {
                Text = "Close",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                BackColor = DarkGray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(150, 45),
                Location = new Point(215, yPos + 180),
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => detailForm.Close();
            contentPanel.Controls.Add(btnClose);

            detailForm.Controls.Add(contentPanel);
            detailForm.Controls.Add(headerPanel);
            detailForm.ShowDialog();
        }

        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void EventsAndAnnouncementsForm_Load(object sender, EventArgs e)
        {
        }
    }
}