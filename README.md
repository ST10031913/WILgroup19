# **Shadow of His Wings Website**

## **Overview**
The **Shadow of His Wings** website is a Christian-centered platform developed to support a rehabilitation center focused on helping individuals recover from drug and alcohol addiction. It is designed to provide information about the center, facilitate donations, share media, manage events, and display testimonials. The website includes both user-facing pages and a robust admin panel for managing content efficiently.

---

## **Features**

### **User-Facing Features**
1. **Home Page**:
   - Features a dynamic gallery showcasing event images.
   - Includes an interactive image carousel for a visually engaging experience.

2. **About Page**:
   - Displays detailed information about the center.
   - Includes embedded Google Maps for location details and videos highlighting the center’s mission.

3. **Donation Page**:
   - Simple and secure interface for financial contributions to the center.

4. **Contact Us Page**:
   - A functional contact form that validates input in real-time and sends inquiries directly to the center's email via MailKit.

5. **Events Page**:
   - Lists upcoming events organized by the center.
   - Automatically updates to reflect newly added or edited events.

6. **Testimonial Page**:
   - Displays testimonials from past beneficiaries.
   - Encourages users through real stories of hope and recovery.

7. **Media Section**:
   - Divided into two parts: Videos (YouTube embeds) and Gallery (event and facility images).
   - Event images are dynamically displayed on the homepage gallery.

8. **Our Counselors Page**:
   - Introduces the team of counselors, showcasing their profiles and social media links.

---

### **Admin Panel Features**
1. **Event Management**:
   - Add, edit, and delete events along with associated images.
   - Automatically updates the Events page and homepage gallery.

2. **Media Management**:
   - Upload and manage categorized images and YouTube videos.
   - Facility images are displayed in the gallery, while event images also appear on the homepage.

3. **Testimonial Management**:
   - Add, edit, or delete testimonials to keep content relevant and inspiring.

4. **Secure Role-Based Access**:
   - Only admins can access the dashboard for managing website content.

5. **Dynamic Updates**:
   - Changes made through the admin panel are reflected instantly on the user-facing pages.

---

## **Technical Details**

### **Technologies Used**
- **Frontend**:
  - **HTML**, **CSS**, and **Bootstrap**: For responsive design and styling.
  - **JavaScript**: For interactivity, preloader functionality, AJAX calls, and smooth transitions.

- **Backend**:
  - **ASP.NET MVC Framework**: For structured development and robust functionality.
  - **Entity Framework Core**: For database management and ORM.
  - **MailKit**: For email handling in the Contact Us page.

### **Preloader Functionality**
- A preloader ensures a smooth transition by displaying a spinner or logo while the page loads. The preloader fades out once the content is ready, enhancing the user experience.

### **Dynamic Gallery**
- The homepage gallery dynamically fetches the most recent event images from the database, keeping the content fresh and relevant.

---

## **Installation Instructions**

### **Requirements**
1. Visual Studio with ASP.NET MVC support.
2. SQL Server for database management.
3. MailKit setup (configured for Outlook).
4. Bootstrap and jQuery libraries (included in the project).

### **Setup Steps**
1. Clone the repository:
   ```bash
   git clone [https://github.com/liam-007/shadow-of-his-wings.git](https://github.com/ST10031913/WILgroup19.git))
   ```
2. Open the project in Visual Studio.
3. Configure the database connection string in the `appsettings.json` file.
4. Run database migrations using Entity Framework:
   ```bash
   dotnet ef database update
   ```
5. Configure MailKit settings for the Contact Us form in the `appsettings.json` file.
6. Build and run the project.

---

## **Usage**
1. Visit the website's homepage to explore its features.
2. Admin users can log in to the admin panel for content management.
3. Use the Donation page to contribute financially to the center’s mission.
4. Contact the center directly through the Contact Us form.

---

## **Future Enhancements**
- Integration of a multilingual feature for wider accessibility.
- Enhanced analytics for admin reporting.
- Additional user roles for content contributors.

---

## **License**
This project is licensed under the MIT License. See the `LICENSE` file for details.

---

## **Contributors**
- **Liam Abraham** – Fullstack Developer and designer.
- **Saneliso Lehlohla** – Fullstack Developer and documentation.
- Supported by the team at **Shadow of His Wings Rehabilitation Center**.

---

## **Contact**
For questions or support, please contact **wilgroup19@gmail.com**.# WILgroup19
