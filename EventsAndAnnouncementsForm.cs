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
        private FlowLayoutPanel eventsContainer;
        private Panel announcementsPanel;
        private Panel recommendationsPanel;

        // Colors
        private static readonly Color PrimaryTeal = Color.FromArgb(0, 123, 139);
        private static readonly Color SecondaryTeal = Color.FromArgb(0, 150, 167);
        private static readonly Color AccentBlue = Color.FromArgb(21, 101, 192);
        private static readonly Color SuccessGreen = Color.FromArgb(76, 175, 80);
        private static readonly Color WarningOrange = Color.FromArgb(255, 152, 0);
        private static readonly Color LightGray = Color.FromArgb(248, 249, 250);
        private static readonly Color DarkGray = Color.FromArgb(66, 66, 66);
        private static readonly Color BorderGray = Color.FromArgb(224, 224, 224);

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
            // Load 20+ sample events
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
                new Event("E020", "Music in the Park", "Culture", new DateTime(2025, 11, 14), "Central Park", "Live music performances every Sunday", "", 3)
            };

            foreach (var evt in events)
            {
                string dateKey = evt.Date.ToString("yyyy-MM-dd");
                eventsByDate.Add(dateKey, evt);
                eventsById.Add(evt.EventId, evt);
                categories.Add(evt.Category);
                uniqueDates.Add(dateKey);

                // Add to priority queue (upcoming events)
                if (evt.Date >= DateTime.Now)
                {
                    upcomingEvents.Enqueue(evt);
                }
            }
        }

        private void BuildUI()
        {
            this.Text = "📢 Local Events & Announcements";
            this.Size = new Size(1200, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = LightGray;

            // Main container
            TableLayoutPanel mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 4,
                ColumnCount = 1,
                Padding = new Padding(0)
            };
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));  // Header
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F)); // Search
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));  // Content
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));  // Footer

            // Header
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
                BackColor = LightGray
            };

            // Events container
            eventsContainer = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                Padding = new Padding(20)
            };
            mainPanel.Controls.Add(eventsContainer);

            mainLayout.Controls.Add(mainPanel, 0, 2);

            // Footer
            Panel footer = CreateFooter();
            mainLayout.Controls.Add(footer, 0, 3);

            this.Controls.Add(mainLayout);

            // Load all events initially
            DisplayEvents(eventsById.GetAllValues());
        }

        private Panel CreateHeader()
        {
            Panel header = new Panel { Dock = DockStyle.Fill };
            header.Paint += (s, e) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    header.ClientRectangle, PrimaryTeal, SecondaryTeal, LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, header.ClientRectangle);
                }
            };

            Label lblTitle = new Label
            {
                Text = "📢 LOCAL EVENTS & ANNOUNCEMENTS",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            header.Controls.Add(lblTitle);

            return header;
        }

        private Panel CreateSearchPanel()
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(20, 10, 20, 10)
            };

            // Search textbox
            txtSearch = new TextBox
            {
                Font = new Font("Segoe UI", 11),
                Width = 250,
                Location = new Point(20, 30),
                Text = "Search events..."
            };
            txtSearch.GotFocus += (s, e) => { if (txtSearch.Text == "Search events...") txtSearch.Text = ""; };
            txtSearch.LostFocus += (s, e) => { if (string.IsNullOrWhiteSpace(txtSearch.Text)) txtSearch.Text = "Search events..."; };

            // Category dropdown
            cmbCategory = new ComboBox
            {
                Font = new Font("Segoe UI", 11),
                Width = 180,
                Location = new Point(290, 30),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbCategory.Items.Add("All Categories");
            foreach (var cat in categories.ToList().OrderBy(c => c))
            {
                cmbCategory.Items.Add(cat);
            }
            cmbCategory.SelectedIndex = 0;

            // Date picker
            dtpDate = new DateTimePicker
            {
                Font = new Font("Segoe UI", 11),
                Width = 180,
                Location = new Point(490, 30),
                Format = DateTimePickerFormat.Short
            };

            // Search button
            btnSearch = new Button
            {
                Text = "🔍 Search",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = AccentBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 120,
                Height = 35,
                Location = new Point(690, 28),
                Cursor = Cursors.Hand
            };
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Click += BtnSearch_Click;

            // Clear filters button
            btnClearFilters = new Button
            {
                Text = "Clear",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = WarningOrange,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 100,
                Height = 35,
                Location = new Point(820, 28),
                Cursor = Cursors.Hand
            };
            btnClearFilters.FlatAppearance.BorderSize = 0;
            btnClearFilters.Click += BtnClearFilters_Click;

            // Show recommendations button
            btnShowRecommendations = new Button
            {
                Text = "⭐ Recommendations",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = SuccessGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 180,
                Height = 35,
                Location = new Point(940, 28),
                Cursor = Cursors.Hand
            };
            btnShowRecommendations.FlatAppearance.BorderSize = 0;
            btnShowRecommendations.Click += BtnShowRecommendations_Click;

            panel.Controls.AddRange(new Control[] {
                txtSearch, cmbCategory, dtpDate, btnSearch, btnClearFilters, btnShowRecommendations
            });

            return panel;
        }

        private Panel CreateFooter()
        {
            Panel footer = new Panel { Dock = DockStyle.Fill };
            footer.Paint += (s, e) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    footer.ClientRectangle, PrimaryTeal, SecondaryTeal, LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, footer.ClientRectangle);
                }
            };

            Label lblFooter = new Label
            {
                Text = "📞 Contact: 0800-123-456  |  ✉️ events@municipality.gov.za  |  © 2025 Municipal Services",
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
                Label noEvents = new Label
                {
                    Text = "No events found matching your criteria.",
                    Font = new Font("Segoe UI", 14),
                    ForeColor = DarkGray,
                    AutoSize = true,
                    Padding = new Padding(20)
                };
                eventsContainer.Controls.Add(noEvents);
                return;
            }

            foreach (var evt in events.OrderBy(e => e.Date))
            {
                eventsContainer.Controls.Add(CreateEventCard(evt));
            }
        }

        private Panel CreateEventCard(Event evt)
        {
            Panel card = new Panel
            {
                Width = 340,
                Height = 220,
                Margin = new Padding(10),
                Cursor = Cursors.Hand,
                Tag = evt
            };

            card.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var rect = new Rectangle(2, 2, card.Width - 4, card.Height - 4);
                var path = GetRoundedRectanglePath(rect, 12);

                using (var brush = new SolidBrush(Color.White))
                    e.Graphics.FillPath(brush, path);
                using (var borderPen = new Pen(BorderGray, 2))
                    e.Graphics.DrawPath(borderPen, path);

                // Category color strip
                Color categoryColor = GetCategoryColor(evt.Category);
                using (var accentBrush = new SolidBrush(categoryColor))
                    e.Graphics.FillRectangle(accentBrush, 0, 0, card.Width, 8);
            };

            // Date badge
            Panel dateBadge = new Panel
            {
                Size = new Size(60, 60),
                Location = new Point(15, 20),
                BackColor = AccentBlue
            };
            dateBadge.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var brush = new SolidBrush(AccentBlue))
                    e.Graphics.FillEllipse(brush, 0, 0, 60, 60);
            };

            Label lblDay = new Label
            {
                Text = evt.Date.Day.ToString(),
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 30
            };
            Label lblMonth = new Label
            {
                Text = evt.Date.ToString("MMM"),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            dateBadge.Controls.Add(lblMonth);
            dateBadge.Controls.Add(lblDay);

            // Event details
            Label lblTitle = new Label
            {
                Text = evt.Title,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = DarkGray,
                Location = new Point(85, 20),
                Size = new Size(240, 50),
                AutoEllipsis = true
            };

            Label lblCategory = new Label
            {
                Text = $"📁 {evt.Category}",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = GetCategoryColor(evt.Category),
                Location = new Point(85, 75),
                AutoSize = true
            };

            Label lblLocation = new Label
            {
                Text = $"📍 {evt.Location}",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                Location = new Point(15, 95),
                Size = new Size(310, 20),
                AutoEllipsis = true
            };

            Label lblDescription = new Label
            {
                Text = evt.Description,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                Location = new Point(15, 120),
                Size = new Size(310, 60),
                AutoEllipsis = true
            };

            Label lblViewDetails = new Label
            {
                Text = "Click to view details →",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = AccentBlue,
                Location = new Point(15, 185),
                AutoSize = true
            };

            card.Controls.AddRange(new Control[] {
                dateBadge, lblTitle, lblCategory, lblLocation, lblDescription, lblViewDetails
            });

            card.Click += (s, e) => ShowEventDetails(evt);
            foreach (Control ctrl in card.Controls)
            {
                ctrl.Click += (s, e) => ShowEventDetails(evt);
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
                default: return DarkGray;
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text == "Search events..." ? "" : txtSearch.Text;
            string selectedCategory = cmbCategory.SelectedItem?.ToString();
            DateTime selectedDate = dtpDate.Value.Date;

            var filteredEvents = eventsById.GetAllValues();

            // Filter by text search
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                filteredEvents = filteredEvents
                    .Where(ev => ev.Title.ToLower().Contains(searchText.ToLower()) ||
                                 ev.Description.ToLower().Contains(searchText.ToLower()))
                    .ToList();
            }

            // Filter by category
            if (selectedCategory != "All Categories" && !string.IsNullOrEmpty(selectedCategory))
            {
                filteredEvents = filteredEvents.Where(ev => ev.Category == selectedCategory).ToList();
                recommendationEngine.TrackCategorySearch(selectedCategory);
            }

            // Filter by date
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
            txtSearch.Text = "Search events...";
            cmbCategory.SelectedIndex = 0;
            dtpDate.Value = DateTime.Now;
            DisplayEvents(eventsById.GetAllValues());
        }

        private void BtnShowRecommendations_Click(object sender, EventArgs e)
        {
            var allEvents = eventsById.GetAllValues();
            var recommendations = recommendationEngine.GetRecommendedEvents(allEvents, 6);

            if (recommendations.Count == 0)
            {
                MessageBox.Show("Start searching for events to get personalized recommendations!",
                    "No Recommendations Yet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Form recForm = new Form
            {
                Text = "⭐ Recommended Events For You",
                Size = new Size(900, 600),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = LightGray
            };

            Panel header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = SuccessGreen
            };
            Label lblHeader = new Label
            {
                Text = "⭐ PERSONALIZED RECOMMENDATIONS\nBased on your search history",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            header.Controls.Add(lblHeader);

            FlowLayoutPanel recFlow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                Padding = new Padding(20)
            };

            foreach (var evt in recommendations)
            {
                recFlow.Controls.Add(CreateEventCard(evt));
            }

            Panel statsPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 80,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(20)
            };
            Label lblStats = new Label
            {
                Text = recommendationEngine.GetSearchStatistics(),
                Font = new Font("Segoe UI", 9),
                ForeColor = DarkGray,
                Dock = DockStyle.Fill
            };
            statsPanel.Controls.Add(lblStats);

            recForm.Controls.Add(recFlow);
            recForm.Controls.Add(header);
            recForm.Controls.Add(statsPanel);
            recForm.ShowDialog();
        }

        private void ShowEventDetails(Event evt)
        {
            // Add to recently viewed
            if (recentlyViewedEvents.Count >= 5)
            {
                recentlyViewedEvents.Dequeue();
            }
            recentlyViewedEvents.Enqueue(evt);

            Form detailForm = new Form
            {
                Text = "Event Details",
                Size = new Size(600, 500),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White
            };

            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = GetCategoryColor(evt.Category)
            };
            Label lblDetailTitle = new Label
            {
                Text = evt.Title,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            headerPanel.Controls.Add(lblDetailTitle);

            Panel contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(30),
                AutoScroll = true
            };

            int yPos = 10;
            void AddDetailLabel(string label, string value)
            {
                Label lbl = new Label
                {
                    Text = $"{label}: {value}",
                    Font = new Font("Segoe UI", 11),
                    Location = new Point(10, yPos),
                    Size = new Size(520, 30),
                    ForeColor = DarkGray
                };
                contentPanel.Controls.Add(lbl);
                yPos += 35;
            }

            AddDetailLabel("📁 Category", evt.Category);
            AddDetailLabel("📅 Date", evt.Date.ToString("dddd, MMMM dd, yyyy"));
            AddDetailLabel("📍 Location", evt.Location);
            AddDetailLabel("📝 Description", "");

            Label lblDesc = new Label
            {
                Text = evt.Description,
                Font = new Font("Segoe UI", 10),
                Location = new Point(30, yPos),
                Size = new Size(500, 100),
                ForeColor = Color.Gray
            };
            contentPanel.Controls.Add(lblDesc);

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