---
name: Atelier Barbershop Management
colors:
  surface: '#fff8f5'
  surface-dim: '#e0d8d5'
  surface-bright: '#fff8f5'
  surface-container-lowest: '#ffffff'
  surface-container-low: '#faf2ee'
  surface-container: '#f4ece8'
  surface-container-high: '#eee7e3'
  surface-container-highest: '#e9e1dd'
  on-surface: '#1e1b19'
  on-surface-variant: '#45464d'
  inverse-surface: '#33302d'
  inverse-on-surface: '#f7efeb'
  outline: '#76777d'
  outline-variant: '#c6c6cd'
  surface-tint: '#565e74'
  primary: '#000000'
  on-primary: '#ffffff'
  primary-container: '#131b2e'
  on-primary-container: '#7c839b'
  inverse-primary: '#bec6e0'
  secondary: '#775a19'
  on-secondary: '#ffffff'
  secondary-container: '#fed488'
  on-secondary-container: '#785a1a'
  tertiary: '#000000'
  on-tertiary: '#ffffff'
  tertiary-container: '#2e1500'
  on-tertiary-container: '#b97434'
  error: '#ba1a1a'
  on-error: '#ffffff'
  error-container: '#ffdad6'
  on-error-container: '#93000a'
  primary-fixed: '#dae2fd'
  primary-fixed-dim: '#bec6e0'
  on-primary-fixed: '#131b2e'
  on-primary-fixed-variant: '#3f465c'
  secondary-fixed: '#ffdea5'
  secondary-fixed-dim: '#e9c176'
  on-secondary-fixed: '#261900'
  on-secondary-fixed-variant: '#5d4201'
  tertiary-fixed: '#ffdcc2'
  tertiary-fixed-dim: '#ffb77b'
  on-tertiary-fixed: '#2e1500'
  on-tertiary-fixed-variant: '#6d3a00'
  background: '#fff8f5'
  on-background: '#1e1b19'
  surface-variant: '#e9e1dd'
typography:
  display-lg:
    fontFamily: Playfair Display
    fontSize: 48px
    fontWeight: '600'
    lineHeight: 56px
    letterSpacing: -0.02em
  display-lg-mobile:
    fontFamily: Playfair Display
    fontSize: 34px
    fontWeight: '600'
    lineHeight: 42px
    letterSpacing: -0.01em
  headline-lg:
    fontFamily: Playfair Display
    fontSize: 32px
    fontWeight: '600'
    lineHeight: 40px
    letterSpacing: -0.01em
  headline-lg-mobile:
    fontFamily: Playfair Display
    fontSize: 26px
    fontWeight: '600'
    lineHeight: 34px
  headline-md:
    fontFamily: Playfair Display
    fontSize: 24px
    fontWeight: '500'
    lineHeight: 32px
  headline-sm:
    fontFamily: Plus Jakarta Sans
    fontSize: 18px
    fontWeight: '600'
    lineHeight: 26px
    letterSpacing: -0.01em
  body-lg:
    fontFamily: Plus Jakarta Sans
    fontSize: 16px
    fontWeight: '400'
    lineHeight: 26px
  body-md:
    fontFamily: Plus Jakarta Sans
    fontSize: 14px
    fontWeight: '400'
    lineHeight: 22px
  body-sm:
    fontFamily: Plus Jakarta Sans
    fontSize: 12px
    fontWeight: '400'
    lineHeight: 18px
  label-lg:
    fontFamily: Plus Jakarta Sans
    fontSize: 14px
    fontWeight: '600'
    lineHeight: 20px
    letterSpacing: 0.01em
  label-md:
    fontFamily: Plus Jakarta Sans
    fontSize: 12px
    fontWeight: '600'
    lineHeight: 16px
    letterSpacing: 0.04em
  label-sm:
    fontFamily: Plus Jakarta Sans
    fontSize: 11px
    fontWeight: '700'
    lineHeight: 14px
    letterSpacing: 0.08em
rounded:
  sm: 0.25rem
  DEFAULT: 0.5rem
  md: 0.75rem
  lg: 1rem
  xl: 1.5rem
  full: 9999px
spacing:
  gutter: 1.5rem
  gutter-mobile: 1rem
  margin: 2.5rem
  margin-mobile: 1rem
  margin-tablet: 1.75rem
  space-xs: 0.25rem
  space-sm: 0.5rem
  space-md: 1rem
  space-lg: 1.5rem
  space-xl: 2.5rem
---

## Brand & Style

This design system expresses the timeless ceremony of the classic grooming salon through a contemporary architectural lens. The interface balances heritage craft with executive-tier efficiency, targeting high-end barbershop operators, master stylists, and an exacting clientele accustomed to bespoke hospitality.

The visual language blends **Refined Minimalist Luxury** with subtle **Bespoke Tactile** cues:
- **Atmosphere:** Sovereign, serene, grounded, and immaculate. The interaction models mimic the tactile confidence of polished shears, oiled walnut, brushed brass fixtures, and soft, heavyweight parchment.
- **Tension:** Crisp midnight structural surfaces contrast against warm alabaster backgrounds, activated by restrained accents of muted bullion and warm burnished copper.
- **Restraint:** High-contrast noise is rejected in favor of breathing room, deliberate hierarchy, razor-sharp alignment, and soft-focus tonal depth.

## Colors

The palette establishes an immediate distinction between executive command zones and fluid appointment management canvases:

- **Dominant Structural Core (`#0F172A` / `#121214`):** Used for persistent framing devices (primary navigation rail, executive header bars, dark summary panels, and terminal actions).
- **Artisan Metallic Highlights (`#C5A059` & `#B87333`):** Reserved strictly for focal interactions—confirmed booking badges, active time slot toggles, VIP status indicators, and primary booking triggers. These are never used for high-volume body content.
- **Canvas & Surface Tiering:** The underlying application canvas rests on warm bone parchment (`#F8F5F0`), with operational containers and booking cards rendered in pure milk white (`#FFFFFF`) framed by hairline warm-stone borders (`#EAE5DC`).
- **Semantic Text Rules:** High-order labels and critical appointment timings utilize deep bistre charcoal (`#1C1917`). Secondary operational metadata, durations, and barber seat specs reside in muted slate (`#64748B`). Inverted dark panels utilize soft chamois (`#F5E6C8`) for secondary metrics.

## Typography

The typographic hierarchy establishes a deliberate editorial cadence:

- **Editorial Crest (Playfair Display):** Used exclusively for high-level numbers, view titles (e.g., "Agenda Semanal", "Resumen de Caja"), and prestigious client names. Its presence is surgical—providing an authentic gentleman's grooming tradition without compromising the rapid scanning required during floor rushes.
- **Instrumental Precision (Plus Jakarta Sans):** Drives all functional UI, data-dense booking timetables, form inputs, and system alerts. Its geometric foundation guarantees razor-sharp legibility on mobile scheduling displays.
- **Micro-copy & Status Tokens:** Sub-labels, pricing tiers, and queue timestamps utilize `label-sm` or `label-md` styled with uppercase treatment and extended letter-spacing to echo stamped leather goods and high-end horology.

## Layout & Spacing

The system implements a rigid 8pt baseline rhythm anchored by a responsive fluid-grid structure:

- **Desktop (1024px+):** Employs an asymmetric multi-pane architecture. A persistent 280px navigation rail holds deep charcoal tone, followed by an operational workstation schedule (12-column grid, 24px gutters, 40px outer canvas margin).
- **Tablet (768px - 1023px):** Condenses navigation to an icon-compact rail (72px). Calendar matrices switch from multi-chair daily overviews to a unified single-station swiper with 20px gutters.
- **Mobile (<768px):** Refits the workspace into a single-column stacked view with a fixed bottom action sheet for immediate walk-in reservations and appointment check-in. The outer canvas margin locks to 16px with 16px component gaps.
- **Rhythm Principle:** Internal card padding never drops below `space-md` (16px), keeping content aerated and eliminating clutter in quick-turnover environments.

## Elevation & Depth

Visual hierarchy rejects exaggerated drop shadows in favor of tailored surface contrast, crisp border definition, and warm, diffused ambient glows:

- **Base Level (Canvas):** Tone `#F8F5F0`. Absolutely flat, tactile, and non-reflective.
- **Resting Operational Surfaces (Cards, Tables):** Solid `#FFFFFF` bordered by a 1px continuous stroke of `#EAE5DC`. Depth is communicated via a double ambient shadow: `0 1px 2px rgba(28, 25, 23, 0.03), 0 4px 16px rgba(15, 23, 42, 0.04)`.
- **Hover & Selected Appointments:** Cards subtly lift using a localized warm-tinted shadow: `0 8px 24px -4px rgba(197, 160, 89, 0.18)` accompanied by an active border shift to `#C5A059`.
- **Flyouts, Modals & Floating Timepickers:** Higher-tier overlays feature a dark-tinted structural shadow: `0 20px 48px -12px rgba(15, 23, 42, 0.22)`, bounded by a 1px perimeter border `#1A2238` when dark, or `#EAE5DC` when light.
- **Glass Shading:** Subdued backdrop-filters (`backdrop-blur-md` with `rgba(253, 251, 247, 0.85)`) are permitted only for sticky scheduling headers and bottom mobile booking bars.

## Shapes

The geometry pairs soft structural silhouettes with precise internal elements:

- **Primary Cards & Containers:** Standardized at `rounded-xl` (1.5rem / 24px) to present an inviting, contemporary, and lounge-inspired feel.
- **Interactive Controls (Inputs, Buttons, Segmented Selectors):** Standardized at `rounded-lg` (1rem / 16px) to maintain a tailored, confident grip.
- **Micro-elements (Pills, Status Badges, Service Tags):** Fully rounded pill geometry (`rounded-full`) to immediately distinguish dynamic metadata from interactive rectangular buttons.

## Components

### Buttons & Action Triggers
- **Primary CTA ("Confirmar Turno", "Nuevo Cliente"):** Solid deep navy background (`#0F172A`) with pure white text and an internal hairline border of gold (`#C5A059`, 1px opacity 40%). Subtle hover transitions to warm obsidian (`#1A2238`) with an amber edge glow.
- **Accent CTA ("Acceso VIP", "Oferta Especial"):** Brushed warm metallic gradient (`linear-gradient(135deg, #D4AF37 0%, #B87333 100%)`) with white text and an inner highlight rim.
- **Secondary Actions:** White ground, charcoal text (`#1C1917`), framed by a 1px border of `#EAE5DC`. Hover states shift the background to `#F8F5F0`.
- **Destructive Actions:** Soft crimson tint (`#FEF2F2`) with deep brick red text (`#991B1B`), strictly unbordered until hovered.

### Appointment Cards & Queue Blocks
- **Standard Card:** Pure white backdrop with a left-hand 4px indicator strip denoting appointment state (Gold: En progreso; Slate: Agendado; Navy: Completado; Copper: VIP/Tratamiento Especial).
- **Card Content Anatomy:** Upper row features the client's name in `headline-sm`, right-aligned monetary value in `label-md`. The lower row contains a pill badge with the designated barber's avatar, duration marker, and time slot.

### Input Fields & Selectors
- **Fields:** Set to a min-height of 48px. Resting state features an `#FFFFFF` surface with a 1px border of `#EAE5DC`.
- **Focus State:** Border shifts definitively to `#C5A059` paired with an instantaneous outer focus halo of `0 0 0 3px rgba(197, 160, 89, 0.15)`. Labels sit crisply above fields in `label-md` slate typography.

### Checkboxes, Radio Buttons & Toggles
- **Radio & Selection Rings:** Precision circles with dual concentric styling. Selected states feature an outer border of `#0F172A` encompassing a centered gold bullet (`#C5A059`).
- **Segmented Station Toggles:** A pill-shaped pill-container in bone `#EAE5DC` housing recessed tabs; the active station slides across on an elevated white disk.

### Specialized BarberiaWA Components
- **Chair Timeline Grid:** Horizontal time columns intersected by barber workstations. Unavailable slots feature soft diagonal micro-striping in warm gray over parchment.
- **Service Tier Chips:** Clickable pill selectors displaying haircut, hot towel shave, and beard treatment options with an embedded icon, service duration, and cost badge.